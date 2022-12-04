using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInt : MonoBehaviour
{
    public Slider volumeSlider;
    public static float volume;
    GameObject[] pauseMode;
    GameObject[] resumeMode;

    public GameObject[] prompt;


    public TMPro.TMP_InputField inputf;
    public GameObject textgo;
    public GameObject settings;
    public TMPro.TMP_Dropdown resDrop;

    Resolution[] resolutions;

    private void Awake()
    {
        settings.SetActive(false);
    }
    private void Start()
    {

        pauseMode = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowWhenResumed");
        resolutions = Screen.resolutions;
        resDrop.ClearOptions();

        List<string> options = new List<string>();

        int currentresIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresIndex = i;
            }
        }

        resDrop.AddOptions(options);
        resDrop.value = currentresIndex;
        resDrop.RefreshShownValue();
        volumeSlider.value = AudioListener.volume;

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

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        //Debug.Log(AudioListener.volume);
    }

    public void setRes(int index)
    {
        Resolution resolution = resolutions[index];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void EnterName()
    {
        if (inputf.text.Length != 0)
        {

            PersistentData.Instance.SetName(inputf.text);
            prompt[0].SetActive(true);
            prompt[1].SetActive(true);
            prompt[2].SetActive(false);
            prompt[3].SetActive(false);
        }
        else
        {

            textgo.SetActive(true);
        }
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void managesettings()
    {
        settings.SetActive(!settings.activeInHierarchy);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Advancelevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitLevel()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
