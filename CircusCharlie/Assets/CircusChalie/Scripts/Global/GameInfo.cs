using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static GameInfo instance;

    public static int playerlife = 3;
    public static int distance = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerlife = 3;
        distance = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
