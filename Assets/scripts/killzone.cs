using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killzone : MonoBehaviour
{
    public bool endgame = false;
    private AudioSource audio;

    public GameObject hsm;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if(!endgame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                ScoreKeeper.Instance.resetScore();
            }
            else
            {
                Destroy(collision.gameObject);
                audio.Play();
                hsm.GetComponent<HighscoreManager>().riseup();
            }
        }
    }
}
