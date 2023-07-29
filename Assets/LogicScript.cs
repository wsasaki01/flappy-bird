using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    int playerScore;
    public Text scoreText;

    int highScore;
    public Text highScoreText;

    public GameObject gameOverScreen;
    public GameObject highScoreNotice;

    public void Start()
    {
        Application.targetFrameRate = 60;
        setHighScore(PlayerPrefs.GetInt("HighScore"));
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        // Get the current scene, and load it again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        highScoreNotice.SetActive(false);

        if (playerScore > highScore)
        {
            setHighScore(playerScore);
            highScoreNotice.SetActive(true);
        }
    }

    public void setHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt("HighScore", newHighScore);
        highScore = newHighScore;
        highScoreText.text = "High Score: " + newHighScore;
    }

    [ContextMenu("Reset High Score")]
    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScore = 0;
        highScoreText.text = "High Score: " + 0;
    }
}
