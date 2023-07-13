using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] goal;

    private float width;


    private void OnEnable()
    {

        //for (int i = 0; i < goal.Length; i++)
        //{
        //    if (GameManager.distance == 90)
        //    {
        //        goal[0].SetActive(true);
        //    }
        //    else
        //    {
        //        goal[0].SetActive(false);
        //    }

        //}
    }

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;


    }

    // Start is called before the first frame update
    void Start()
    {
        goal[0].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < goal.Length; i++)
        {
            if (GameManager.distance == 0)
            {
                goal[0].SetActive(true);
            }
            else
            {
                goal[0].SetActive(false);
            }

        }

        if (transform.position.x <= -width)
        {
            Reposition_Right();
        }

        else if (transform.position.x >= width)
        {
            Reposition_Left();
        }
    }

    private void Reposition_Right()
    {
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = transform.position.AddVector(offset);

        GameManager.instance.RemoveDistance();
        Debug.Log("거리를 줄여야겠다.");


    }
    private void Reposition_Left()
    {
        Vector2 offset = new Vector2(-width * 2f, 0f);
        transform.position = transform.position.AddVector(offset);

        GameManager.instance.AddDistance();
        Debug.Log("거리를 늘려야겠다.");


    }

}
