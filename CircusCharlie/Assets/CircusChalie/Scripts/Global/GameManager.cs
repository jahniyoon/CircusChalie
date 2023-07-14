using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public bool isClear = false;

    public TMP_Text scoreText;
    public TMP_Text bestscoreText;
    public TMP_Text stageText;

    public TMP_Text distance1Text;
    public TMP_Text distance2Text;

    public GameObject gameOverUi;
    public GameObject clearUi;

    public GameObject playerlife_1;
    public GameObject playerlife_2;
    public GameObject playerlife_3;


    private int highscore = 0;
  

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
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

        Initialization();

        if (GameInfo.distance % 20 !=0)
        {
            GameInfo.distance += 10;

            if (GameInfo.distance == 0)
            {
                GameInfo.distance = 20;
            }

        }
        stageText.text = string.Format("STAGE - 0{0}", GameInfo.stage);
        scoreText.text = string.Format("SCORE  - {0}", GameInfo.score);
        highscore = PlayerPrefs.GetInt("HighScore");
        bestscoreText.text = string.Format("HIGH - {0}", highscore);

        distance1Text.text = string.Format("{0}", GameInfo.distance);

    }

    // Update is called once per frame
    void Update()
    {
        // ���ӿ��� �� �̵�
        if (isGameOver == true && Input.GetMouseButtonDown(0) || isGameOver == true && Input.GetKeyDown(KeyCode.Space))
        {

            //if (GameInfo.playerlife > 0 && GameInfo.stage == 1)
            //{
            //    GlobalFunc.LoadScene("LoadScene");

            //    //GlobalFunc.LoadScene("Stage1Scene");
            //}
            //else if (GameInfo.playerlife > 0 && GameInfo.stage == 2)
            //{
            //    GlobalFunc.LoadScene("LoadScene");

            //    //GlobalFunc.LoadScene("Stage2Scene");
            //}

            if (GameInfo.playerlife > 0)
            {
                GlobalFunc.LoadScene("LoadScene");
            }

            else
            {
                GameInfo.stage = 1;
                GlobalFunc.LoadScene("TitleScene");
            }

        }

        // �������� Ŭ���� �� �̵�
        if (isClear == true && Input.GetMouseButtonDown(0) || isClear == true && Input.GetKeyDown(KeyCode.Space))
        {
            GameInfo.distance = 60;
            GameInfo.stage += 1;
            if (GameInfo.stage <= 2)
            {
                GlobalFunc.LoadScene("LoadScene");
            }
            else
            {
                GameInfo.stage = 1;
                GlobalFunc.LoadScene("EndingScene");
            }


            //if (GameInfo.stage == 2)
            //{
            //    stageText.text = string.Format("STAGE - 0{0}", GameInfo.stage);
            //    GlobalFunc.LoadScene("Stage2Scene");
            //}
            //if (GameInfo.stage == 3)
            //{

            //    GlobalFunc.LoadScene("EndingScene");
            //}

        }

        PlayerLife();
    }
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //���� ����
            GameInfo.score += newScore;
            scoreText.text = string.Format("SCORE  - {0}", GameInfo.score);

            if (highscore < GameInfo.score)
            {
                //���� ����
                highscore = GameInfo.score;
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
            if (101 > GameInfo.distance)
            {
                GameInfo.distance += 10;
                distance1Text.text = string.Format("{0}", GameInfo.distance);
                distance2Text.text = string.Format("{0}", GameInfo.distance);
            }
        }
    }
    public void RemoveDistance()
    {
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //�Ÿ� ����
            if (GameInfo.distance > 0)
            {
                //�Ÿ� ����
                GameInfo.distance -= 10;
                distance1Text.text = string.Format("{0}", GameInfo.distance);
                distance2Text.text = string.Format("{0}", GameInfo.distance);
            }
        }
    }

    public void OnPlayerDead()
    {
        GameInfo.score = 0;


        isGameOver = true;
        gameOverUi.SetActive(true);
        GameInfo.playerlife -= 1;
        highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore < GameInfo.score)
        {
            //���� ����
            highscore = GameInfo.score;
            PlayerPrefs.SetInt("HighScore", highscore);
            bestscoreText.text = string.Format("HIGH - {0}", highscore);
        }
    }


    public void OnPlayerClear()
    {
        isClear = true;
        clearUi.SetActive(true);


        highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore < GameInfo.score)
        {
            //���� ����
            highscore = GameInfo.score;
            PlayerPrefs.SetInt("HighScore", highscore);
            bestscoreText.text = string.Format("HIGH - {0}", highscore);
        }
    }

    public void PlayerLife()
    {
        if (GameInfo.playerlife == 3)
        {
            playerlife_1.SetActive(true);
            playerlife_2.SetActive(true);
            playerlife_3.SetActive(true);
        }

        else if (GameInfo.playerlife == 2)
        {
            playerlife_1.SetActive(true);
            playerlife_2.SetActive(true);
            playerlife_3.SetActive(false);
        }
        else if (GameInfo.playerlife == 1)
        {
            playerlife_1.SetActive(true);
            playerlife_2.SetActive(false);
            playerlife_3.SetActive(false);
        }
        else if (GameInfo.playerlife == 0)
        {
            playerlife_1.SetActive(false);
            playerlife_2.SetActive(false);
            playerlife_3.SetActive(false);
        }

    }

    public void Initialization()
    {

        isGameOver = false;
        isClear = false;

        StageController.isDead = false;
        StageController.isClear = true;

        PlayerController.isClearArea = false;
        PlayerController2.isClearArea = false;


    }
}
