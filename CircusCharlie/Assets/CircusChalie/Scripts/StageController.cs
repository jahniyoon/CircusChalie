using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{


    public float speed = 5f;

    private bool isGrounded = false;

    private Rigidbody2D playerRigid = default;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

            float xInput = Input.GetAxis("Horizontal");
            float xSpeed = xInput * speed * -1;

            Vector2 newVelocity = new Vector2(xSpeed, playerRigid.velocity.y);
            playerRigid.velocity = newVelocity;

    }
}
