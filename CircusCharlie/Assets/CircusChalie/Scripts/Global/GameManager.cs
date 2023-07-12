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
    public TMP_Text distance3Text;
    
    public GameObject gameOverUi;

    private int score = 0;
    private int highscore = 0;
    private int distance = 100;

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

    public void DistanceIs(int newDistance)
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            distance = newDistance;
            //�Ÿ� ����
            distance1Text.text = string.Format("{0}", distance);
            distance2Text.text = string.Format("{0}", distance);
            distance3Text.text = string.Format("{0}", distance);

        }
    } public void AddDistance()
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //�Ÿ� ����
            distance += 10;
            distance1Text.text = string.Format("{0}", distance);
            distance2Text.text = string.Format("{0}", distance);
            distance3Text.text = string.Format("{0}", distance);

        }
    }
    public void RemoveDistance()
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //�Ÿ� ����
            distance -= 10;
            distance1Text.text = string.Format("{0}", distance);
            distance2Text.text = string.Format("{0}", distance);
            distance3Text.text = string.Format("{0}", distance);

        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore < score)
        {
            //���� ����
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            bestscoreText.text = string.Format("HIGH - {0}", highscore);
        }
    }
}
