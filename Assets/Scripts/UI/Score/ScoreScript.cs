using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    // добавляем очки в общий счет в зависимости от предмета
    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = "Score: " + score.ToString();  // выводим счет очков на экран
    }
}
