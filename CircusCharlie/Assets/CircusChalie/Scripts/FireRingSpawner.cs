using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class FireRingSpawner : MonoBehaviour
{
    public GameObject fireringPrefab;
    public GameObject fireringSmallsPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    public float yPos = 0.2f;
    private float xPos = 13f;
    private float xPosSmall = 15;

    private int smallCount = 0;

    private GameObject[] firerings;
    private int currentIndex = 0;

    private GameObject fireringSmalls;


    private Vector2 poolPosition = new Vector2(0, -25f);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        firerings = new GameObject[count];

        
        for (int i = 0; i < count; i++)
        {
            firerings[i] = Instantiate(fireringPrefab, poolPosition, Quaternion.identity);
            firerings[i].transform.SetParent(transform);

        }
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;

        fireringSmalls = Instantiate(fireringSmallsPrefab, poolPosition, Quaternion.identity); // 인스턴스 생성
        fireringSmalls.transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        if (lastSpawnTime + timeBetSpawn <= Time.time)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            firerings[currentIndex].SetActive(false);
            firerings[currentIndex].SetActive(true);
            firerings[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex += 1;
            smallCount += 1;

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }

            if (smallCount == 5)
            {
                fireringSmalls.SetActive(false);
                fireringSmalls.SetActive(true);
                fireringSmalls.transform.position = new Vector2(xPosSmall, yPos);
                smallCount = 0;

            }

        }
        
    }
}
