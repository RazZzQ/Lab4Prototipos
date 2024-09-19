using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI MaxScore;
    [SerializeField] private SO_Score ScoreData;
    public PlayerCollectablesCollision player;
    // Start is called before the first frame update
    void Start()
    {
        ScoreData.CurrentScore = 0;
        UpdateScoreMaxScore();
        MaxScore.text = ScoreData.MaxScore.ToString();
        ShowCurrentScore();
    }

    private void Update()
    {
        UpdateScoreMaxScore();

        ShowCurrentScore();
    }
    private void OnEnable()
    {
        player.CollisionPoints += ScoreAdd;
    }
    private void OnDisable()
    {
        player.CollisionPoints -= ScoreAdd;
    }
    private void UpdateScoreMaxScore()
    {
        if (ScoreData.CurrentScore > ScoreData.MaxScore)
        {
            ScoreData.MaxScore = ScoreData.CurrentScore;
            MaxScore.text = ScoreData.MaxScore.ToString();
        }
    }
    private void ShowCurrentScore()
    {
        Score.text = ScoreData.CurrentScore.ToString();
    }
    void ScoreAdd()
    {
        AddScore(1);
    }
    void AddScore(int score)
    {
        ScoreData.CurrentScore += score;
    }
}
