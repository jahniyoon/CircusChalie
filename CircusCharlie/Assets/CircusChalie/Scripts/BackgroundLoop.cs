using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    private float width;

    private int leftCount = 0;
    private int rightCount = 0;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width * 2 )
        {
            Reposition_Right();
        }

        else if (transform.position.x >= width * 2)
        {
            Reposition_Left();
        }
    }

    private void Reposition_Right()
    {
        Vector2 offset = new Vector2(width * 3.3f, 0f);
        transform.position = transform.position.AddVector(offset);
        GameManager.instance.RemoveDistance();
        Debug.Log("거리를 줄여야겠다.");


    }
    private void Reposition_Left()
    {
        Vector2 offset = new Vector2(-width * 3.3f, 0f);
        transform.position = transform.position.AddVector(offset);
        GameManager.instance.AddDistance();
        Debug.Log("거리를 늘려야겠다.");


    }

}
