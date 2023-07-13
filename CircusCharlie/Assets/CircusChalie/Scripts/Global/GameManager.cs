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

    public TMP_Text distance1Text;
    public TMP_Text distance2Text;

    public GameObject gameOverUi;
    public GameObject clearUi;

    public GameObject playerlife_1;
    public GameObject playerlife_2;
    public GameObject playerlife_3;


    private int score = 0;
    private int highscore = 0;
    public static int distance = 20;

    private int playerlife = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GlobalFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�.");
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
        PlayerLife();
    }
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //���� ����
            score += newScore;
            scoreText.text = string.Format("SCORE  - {0}", score);

            if (highscore < score)
            {
                //���� ����
                highscore = score;
                PlayerPrefs.SetInt("HighScore", highscore);
                bestscoreText.text = string.Format("HIGH - {0}", highscore);
            }
        }
    }


    public void AddDistance()
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //�Ÿ� ����
            if (101 > distance)
            {
                distance += 10;
                distance1Text.text = string.Format("{0}", distance);
                distance2Text.text = string.Format("{0}", distance);
            }
        }
    }
    public void RemoveDistance()
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //�Ÿ� ����
            if (distance > 0)
            {
                //�Ÿ� ����
                distance -= 10;
                distance1Text.text = string.Format("{0}", distance);
                distance2Text.text = string.Format("{0}", distance);
            }
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
        playerlife -= 1;
        highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore < score)
        {
            //���� ����
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            bestscoreText.text = string.Format("HIGH - {0}", highscore);
        }
    }


    public void OnPlayerClear()
    {
        isGameOver = true;
        clearUi.SetActive(true);

        highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore < score)
        {
            //���� ����
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            bestscoreText.text = string.Format("HIGH - {0}", highscore);
        }
    }

    public void PlayerLife()
    {
        if (playerlife == 3)
        {
            playerlife_1.SetActive(true);
            playerlife_2.SetActive(true);
            playerlife_3.SetActive(true);
        }

        else if (playerlife == 2)
        {
            playerlife_1.SetActive(true);
            playerlife_2.SetActive(true);
            playerlife_3.SetActive(false);
        }
        else if (playerlife == 1)
        {
            playerlife_1.SetActive(true);
            playerlife_2.SetActive(false);
            playerlife_3.SetActive(false);
        }
        else if (playerlife == 0)
        {
            playerlife_1.SetActive(false);
            playerlife_2.SetActive(false);
            playerlife_3.SetActive(false);
        }

    }
}
