using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High score: " + highScore.ToString();
    }
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
