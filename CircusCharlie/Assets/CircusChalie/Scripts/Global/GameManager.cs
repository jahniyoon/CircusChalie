using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;
    public TMP_Text bestscoreText;
    public GameObject gameOverUi;

    private int score = 0;
    private int highscore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GlobalFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        bestscoreText.text = string.Format("HIGH - {0}", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0) || isGameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            //GlobalFunc.LoadScene("PlayerScene");
            GlobalFunc.LoadScene(GlobalFunc.GetActiveSceneName());
        }
    }
    public void AddScore(int newScore)
    {
        // 게임오버가 아니라면
        if (isGameOver == false)
        {
            //점수 증가
            score += newScore;
            scoreText.text = string.Format("SCORE  - {0}", score);

            if (highscore < score)
            {
                //점수 증가
                highscore = score;
                PlayerPrefs.SetInt("HighScore", highscore);
                bestscoreText.text = string.Format("HIGH - {0}", highscore);
            }
        }
    }
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore < score)
        {
            //점수 증가
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            bestscoreText.text = string.Format("HIGH - {0}", highscore);
        }
    }
}
