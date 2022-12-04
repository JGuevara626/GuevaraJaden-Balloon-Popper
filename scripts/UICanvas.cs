using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UICanvas : MonoBehaviour
{
    public Slider volumeSlider;
    public static float volume;
    GameObject[] pauseMode;
    GameObject[] resumeMode;

    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI sceneTxt;

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
            g.SetActive(false);
    }

    private void Update()
    {
        scoreTxt.text = ScoreKeeper.Instance.DisplayScore();
        sceneTxt.text = ScoreKeeper.Instance.DisplaylevelNum();
    }

    public void PauseResume(int i)
    {
        if(i == 1)
        {
            Time.timeScale = 0.0f;
            foreach (GameObject g in pauseMode)
                g.SetActive(true);

            foreach (GameObject g in resumeMode)
                g.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            foreach (GameObject g in pauseMode)
                g.SetActive(false);

            foreach (GameObject g in resumeMode)
                g.SetActive(true);
        }
    }

    public void QuitLevel()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        PauseResume(0);
        ScoreKeeper.Instance.resetScore();
        PersistentData.Instance.resetScore();
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void managesettings()
    {
        settings.SetActive(!settings.activeInHierarchy);
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
}
