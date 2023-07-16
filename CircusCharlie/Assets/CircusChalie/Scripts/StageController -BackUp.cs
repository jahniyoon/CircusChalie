using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController_ : MonoBehaviour
{


    public float speed = 5f;

    public static bool isDead;  // ���� Ȯ��
    public static bool isClear; // Ŭ���� Ȯ��

    public static bool isClearZone = true; // Ŭ������ Ȯ��


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
        // �÷��̾ ����ְų� Ŭ���� ���̸�� �ƴҶ� üũ
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
                //Debug.Log("�ӵ��� 0�̴�.");
            }
            else
            {
                PlayerController.isStand = false;
                //Debug.Log("�ӵ��� ����.");
            }
        }

        else 
        {
            playerRigid.velocity = Vector2.zero;
        }

        // Ŭ�����ϸ� ��� �ִϸ��̼� ����
        if (isClear == true)
        {
            clearAnimatorLeft.SetTrigger("Clear");
            clearAnimatorRight.SetTrigger("Clear");
        }



    }
}
