using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    public float movement;
    public Rigidbody2D rigid;
    public int speed = 5;
    public float InvokeSpeed = 2;
    [SerializeField] int limit = 10;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] AudioSource audio;

    [SerializeField] int score = 500;

    public GameObject door;
    public bool defaultRun = true;
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (audio == null)
            audio = GetComponent<AudioSource>();
        if(door == null)
            door = GameObject.FindGameObjectWithTag("Door");

        InvokeRepeating("increaseSize", 3, InvokeSpeed);
    }

    void FixedUpdate()
    {

        defaultMovement();
    }

    void defaultMovement()
    {
        if(defaultRun)
        {
            if ((transform.position.x >= limit && isFacingRight) || (transform.position.x <= -limit && !isFacingRight))
                flip();

            if (isFacingRight && transform.position.x < limit)
            {
                movement = 1;
                rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
            }
            else if (!isFacingRight && transform.position.x > -limit)
            {
                movement = -1;
                rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
            }
        }
    }

    void flip()
    {
        GetComponent<SpriteRenderer>().flipX = isFacingRight;
        isFacingRight = !isFacingRight;
    }

    public void takeDMG()
    {
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        //GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        //controller.GetComponent<ScoreKeeper>().AddPoints(score);
        ScoreKeeper.Instance.AddPoints(score);
        
        door.GetComponent<Door>().Open();

        Destroy(gameObject);
    }

    void increaseSize()
    {
        gameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0);
        score -= 25;

        if(gameObject.transform.localScale.x >= 7)
        {
            score = 0;
            takeDMG();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
