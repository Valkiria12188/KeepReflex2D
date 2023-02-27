using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text tapToPlayText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreText2;
    [SerializeField] private Text highScore;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject mainCanvas;

    private AudioManager audioManager;
    public int score;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    private void Start()
    {
        Time.timeScale = 0f;
        score = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        TapToStart();
    }

    private void TapToStart()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (tapToPlayText) tapToPlayText.enabled = false;
            Time.timeScale = 1f;
            audioManager.OnGameStart();
        }
    }

    public void DelayGameOver()
    {
        audioManager.OnGameOver();
        Invoke("GameOver", 3f);
    }

    public void GameOver()
    {
        if (mainCanvas) mainCanvas.SetActive(false);
        scoreText2.text = score.ToString();
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void IncreaseScore()
    {
        audioManager.OnPointEarned();
        score++;
        scoreText.text = "Score: " + score.ToString();
        scoreText2.text = "Score: " + score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.GetInt("HighScore", score);
            highScore.text = "HighScore: " + score.ToString();
        }
    }
}
