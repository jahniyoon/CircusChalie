using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public float speed = 5f;

    public static bool isDead;  // 죽음 확인
    public static bool isClear; // 클리어 확인
    public static bool isClearZone = true; // 클리어존 확인

    private Animator clearAnimatorLeft = default;
    private Animator clearAnimatorRight = default;
    private Rigidbody2D playerRigid = default;

    void Start()
    {
        isClear = false;
        isClearZone = true;

        playerRigid = GetComponent<Rigidbody2D>();

        clearAnimatorLeft = transform.Find("BG_Stage1_Left").GetComponent<Animator>();
        clearAnimatorRight = transform.Find("BG_Stage1_Right").GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead == false && isClearZone == true)
        {
            float xInput = Input.GetAxis("Horizontal");
            float xSpeed = xInput * speed * -1;

            Vector2 newVelocity = new Vector2(xSpeed, playerRigid.velocity.y);
            playerRigid.velocity = newVelocity;

            if (xSpeed == 0)
            {
                PlayerController.isStand = true;
            }
            else
            {
                PlayerController.isStand = false;
            }
        }
        else
        {
            playerRigid.velocity = Vector2.zero;
        }

        if (isClear == true)
        {
            clearAnimatorLeft.SetTrigger("Clear");
            clearAnimatorRight.SetTrigger("Clear");
        }
    }

 
}
