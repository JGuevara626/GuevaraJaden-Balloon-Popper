using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowardBalloon : Balloon
{
    [Space(20)]
    public bool isChasedX = false;
    public int chaseX;
    public bool isChasedY = false;
    public int chaseY;
    [Space(10)]
    public LayerMask whatIsGrounded;
    private void FixedUpdate()
    {

        if (isChasedX)
            rigid.velocity = new Vector2(chaseX * speed, rigid.velocity.y);
        else
            rigid.velocity = Vector2.zero;

        if (isChasedY)
            rigid.velocity = new Vector2(rigid.velocity.x, chaseY * speed);
        else
            rigid.velocity = Vector2.zero;
    }

    public void runx(int i)
    {
        chaseX = i;
    }
    public void runy(int i)
    {
        chaseY = i;
    }
}
