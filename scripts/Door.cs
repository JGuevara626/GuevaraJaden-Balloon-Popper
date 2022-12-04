using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] GameObject controller;
    [SerializeField] AudioSource audio;
    private void Start()
    {
        gameObject.SetActive(false);
        //controller = GameObject.FindGameObjectWithTag("GameController");
        if (audio == null)
            audio = GetComponent<AudioSource>();
    }

    public void Open()
    {
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreKeeper.Instance.AdvancelevelNum();
    }
}
