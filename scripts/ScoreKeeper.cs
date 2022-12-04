using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public int levelNum;

    const int defaultPoint = 12;

    public static ScoreKeeper Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DisplaylevelNum();
        DisplayScore();
    }

    private void Update()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;
        
    }
    public void AddPoints(int points)
    {
        score += points;
        DisplayScore();

    }
    public void AddPoints()
    {
        AddPoints(defaultPoint);
        
    }

    public string DisplayScore()
    {
        return "Score: " + (PersistentData.Instance.GetScore() + score);
    }

    public string DisplaylevelNum()
    {
        int l = levelNum;
        return "level: " + l;
    }

    public void AdvancelevelNum()
    {
        SceneManager.LoadScene(levelNum + 1);
        PersistentData.Instance.updateScore(score);
        score = 0;
    }

    public void resetScore()
    {
        score = 0;
    }
}
