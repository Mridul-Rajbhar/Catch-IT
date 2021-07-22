using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text scoreText, highScoreText;
    private int score, highScore;
    private void Awake()
    {
        score = PlayerPrefs.GetInt("currentScore");
        highScore = PlayerPrefs.GetInt("highscore");
    }
    private void Update()
    {
        //Debug.Log(score);
        scoreText.text = "Your Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        
    }
    public void Quit()
    {

        Application.Quit();
    }

}
