using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highscoreText;

    public void Start()
    {
        float highscore = PlayerPrefs.GetFloat("highscore", -1f);

        if (highscore < 0)
        {
            highscoreText.text = "Fastest time to catch them all: N/A";
        }
        else
        {
            highscoreText.text = "Fastest time to catch them all: " + highscore.ToString();
        }
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Psyduck");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
