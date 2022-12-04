using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName;

    public static PersistentData Instance;

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
        playerScore = 0;
        playerName = "";

    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void updateScore(int s)
    {
        playerScore += s;
    }
    public void SetScore(int s)
    {
        playerScore = s;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void resetScore()
    {
        playerScore = 0;
    }
}
