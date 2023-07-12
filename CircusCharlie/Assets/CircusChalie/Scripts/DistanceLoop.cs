using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceLoop : MonoBehaviour
{

    private float width = 10f;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();

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

        if (transform.position.x >= width * 2)
        {
            Reposition_Right();
        }

    }

    private void Reposition_Right()
    {
        Vector2 offset = new Vector2(width * 3.3f, 0f);
        transform.position = transform.position.AddVector(offset);
    }

    private void Reposition_Left()
    {
        Vector2 offset = new Vector2(-width * 3.3f, 0f);
        transform.position = transform.position.AddVector(offset);
    }


}
