using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dart : MonoBehaviour
{
    [SerializeField] int speed = 20;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AudioSource audio;
    public AudioClip ac;
    private void Start()
    {
        rb.velocity = transform.right * speed;
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            collision.GetComponent<Balloon>().takeDMG();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Distraction")
        {
            AudioSource.PlayClipAtPoint(ac, transform.position);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            collision.gameObject.GetComponent<Balloon>().takeDMG();
            Destroy(gameObject);
        }




    }
}
