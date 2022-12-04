using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 400f;
	[SerializeField] bool isGrounded = true;
	[Space(20)]
	[SerializeField] Transform shooter;
	[SerializeField] GameObject dart;
	[SerializeField] AudioSource audio;

	public GameObject groundCheck;
	private Animator anim;
	private string currentAnim;
	public void Start()
	{
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
		if (audio == null)
			audio = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();	

	}

	void Update()
	{
		movement = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump"))
			jumpPressed = true;

		if (Input.GetButtonDown("Fire1"))
		{
			anim.SetTrigger("isShoot");
			StartCoroutine(Shoot());
		}
	}

	void FixedUpdate()
	{
		Moving();
		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
			Flip();
		if (jumpPressed && isGrounded)
			Jump();
	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight;
	}

	void Jump()
	{
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		anim.SetBool("isJump", true);
		jumpPressed = false;
		isGrounded = false;
	}

	void Moving()
	{
		anim.SetFloat("isMove", Mathf.Abs(movement));
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);

    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
			anim.SetBool("isJump", false);
		}
	}

	IEnumerator Shoot()
    {
		GameObject go = Instantiate(dart, shooter.position, shooter.rotation);
		AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        yield return new WaitForSeconds(1);

		Destroy(go);

    }
}
