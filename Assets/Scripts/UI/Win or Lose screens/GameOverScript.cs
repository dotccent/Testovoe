using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    public Text scoreText;

    public void GameOverSetup()
    {
        gameObject.SetActive(true);
        scoreText.text = scoreScript.scoreText.text;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
