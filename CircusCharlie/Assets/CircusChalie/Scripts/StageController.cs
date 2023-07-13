using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{


    public float speed = 5f;

    public static bool isDead;
    public static bool isClearArea;

    private Rigidbody2D playerRigid = default;

    //private int stageCount = 0;

    //public Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        //startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false && isClearArea == true)
        {
            float xInput = Input.GetAxis("Horizontal");
            float xSpeed = xInput * speed * -1;

            Vector2 newVelocity = new Vector2(xSpeed, playerRigid.velocity.y);
            playerRigid.velocity = newVelocity;

            //// Get the player's current position.
            //Vector2 playerPosition = transform.position;

            //// Calculate the distance the player has moved.
            //float distanceMoved = (playerPosition - startingPosition).magnitude;

            // Print the distance the player has moved to the console.
            //Debug.Log("The player has moved " + distanceMoved + " units.");
            if (xSpeed == 0)
            {
                PlayerController.isStand = true;
                Debug.Log("속도가 0이다.");
            }
            else
            {
                PlayerController.isStand = false;
                Debug.Log("속도가 있음.");
            }
        }

        else 
        {
            playerRigid.velocity = Vector2.zero;
        }

       

    }
}
