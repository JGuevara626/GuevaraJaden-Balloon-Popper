using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    GameObject[] pauseMode;
    GameObject[] resumeMode;

    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowWhenResumed");

        foreach (GameObject g in pauseMode)
        {
            g.SetActive(false);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(true);

        foreach (GameObject g in resumeMode)
            g.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in resumeMode)
            g.SetActive(true);

    }

}
