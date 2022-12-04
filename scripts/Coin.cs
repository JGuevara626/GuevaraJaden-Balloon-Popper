using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //[SerializeField] GameObject controller;
    [SerializeField] AudioSource audio;
    void Awake()
    {
        //if (controller == null)
        //{
        //    controller = GameObject.FindGameObjectWithTag("GameController");
        //}
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            ScoreKeeper.Instance.AddPoints();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
        }

    }

}
