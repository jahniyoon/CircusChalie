using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController_ : MonoBehaviour
{


    public float speed = 5f;

    public static bool isDead;  // 죽음 확인
    public static bool isClear; // 클리어 확인

    public static bool isClearZone = true; // 클리어존 확인


    private Animator clearAnimatorLeft = default;
    private Animator clearAnimatorRight = default;

    private Rigidbody2D playerRigid = default;

    //private int stageCount = 0;

    //public Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        isClearZone = true;

        playerRigid = GetComponent<Rigidbody2D>();
        //startingPosition = transform.position;

        clearAnimatorLeft = transform.Find("BG_Stage1_Left").GetComponent<Animator>();
        clearAnimatorRight = transform.Find("BG_Stage1_Right").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 살아있거나 클리어 에이리어가 아닐때 체크
        if (isDead == false && isClearZone == true)
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
                //Debug.Log("속도가 0이다.");
            }
            else
            {
                PlayerController.isStand = false;
                //Debug.Log("속도가 있음.");
            }
        }

        else 
        {
            playerRigid.velocity = Vector2.zero;
        }

        // 클리어하면 배경 애니메이션 실행
        if (isClear == true)
        {
            clearAnimatorLeft.SetTrigger("Clear");
            clearAnimatorRight.SetTrigger("Clear");
        }



    }
}
