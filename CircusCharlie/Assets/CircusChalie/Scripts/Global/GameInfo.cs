using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static GameInfo instance;

    public static int playerlife = 3;
    public static int distance = 60;
    public static int score = 0;
    public static int stage = 1;


    // Start is called before the first frame update
    void Start()
    {
        playerlife = 3;
        distance = 60;
        score = 0;

        //PlayerPrefs.SetInt("HighScore", 0); 하이스코어 초기화

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
