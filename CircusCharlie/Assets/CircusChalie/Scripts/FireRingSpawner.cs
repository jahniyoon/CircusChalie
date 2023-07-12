using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class FireRingSpawner : MonoBehaviour
{
    public GameObject fireringPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    public float yPos = 0.2f;
    private float xPos = 20f;

    private GameObject[] firerings;
    private int currentIndex = 0;

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

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }
        }
        
    }
}
