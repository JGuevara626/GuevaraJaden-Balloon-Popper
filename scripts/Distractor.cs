using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor : MonoBehaviour
{
    public float movement;
    public Rigidbody2D rigid;
    public int speed = 3;
    [SerializeField] int limit = 4;
    [SerializeField] bool isFacingRight = true;

    private void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        defaultMovement();
    }

    void defaultMovement()
    {

        if ((transform.position.y >= (2 + limit) && isFacingRight) || (transform.position.y <= (2 - limit) && !isFacingRight))
            flip();

        if (isFacingRight && transform.position.y < (2 + limit))
            {
                movement = 1;
                rigid.velocity = new Vector2(rigid.velocity.x, movement * speed);
            }
            else if (!isFacingRight && transform.position.y > (2 - limit))
            {
                movement = -1;
                rigid.velocity = new Vector2(rigid.velocity.x, movement * speed);
        }
    }

    void flip()
    {
        //GetComponent<SpriteRenderer>().flipY = isFacingRight;
        isFacingRight = !isFacingRight;
    }

}
