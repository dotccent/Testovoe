using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    public Text scoreText;

    public void WinScreenSetup()
    {
        gameObject.SetActive(true);
        scoreText.text = scoreScript.scoreText.text;
    }

}
