using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runFrom : MonoBehaviour
{
    public cowardBalloon balloon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var v = collision.transform.localPosition;
            var b = balloon.gameObject.transform.localPosition;
            if (v.y < b.y)
            {
                balloon.isChasedY = true;
                balloon.runy(1);
            }
            else
            {
                balloon.isChasedY = true;
                balloon.runy(-1);
            }

            if (v.x < b.x)
            {
                balloon.isChasedX = true;
                balloon.runx(1);
            }
            else
            {
                balloon.isChasedX = true;
                balloon.runx(-1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            balloon.isChasedY = false;
            balloon.isChasedX = false;

        }

    }
}
