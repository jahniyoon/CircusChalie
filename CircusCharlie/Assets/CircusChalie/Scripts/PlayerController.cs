using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 500;
    public float speed = 5f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    public static bool isStand = false;
    public static bool isClearArea = false;


    private Rigidbody2D playerRigid = default;

    // 자식 개체에게 애니메이션 주기
    private Animator charlieAnimator = default;
    private Animator lionAnimator = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();

        // 자식개체 컴포넌트 가져오기
        charlieAnimator = transform.Find("Charlie").GetComponent<Animator>();
        lionAnimator = transform.Find("Lion").GetComponent<Animator>();

        StageController.isDead = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (isDead) { return; }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));

            Audio audio = FindObjectOfType<Audio>();
            audio.JumpSound();
        }
        //animator.SetBool("Grounded", isGrounded); //Ground 는 꼭 복사 붙여넣기로 하는 습관 하기.

        if (isClearArea == true)
        {
            float xInput = Input.GetAxis("Horizontal");
            float xSpeed = xInput * speed;

            Vector2 newVelocity = new Vector2(xSpeed, playerRigid.velocity.y);
            playerRigid.velocity = newVelocity;
        }

        


        charlieAnimator.SetBool("Grounded", isGrounded);
        lionAnimator.SetBool("Grounded", isGrounded);



    }
    private void Die()
    {

        // 죽음 애니메이션
        charlieAnimator.SetTrigger("Die");
        lionAnimator.SetTrigger("Die");


        playerRigid.velocity = Vector2.zero;

        playerRigid.AddForce(new Vector2(0, jumpForce));
        playerRigid.velocity = Vector2.zero;
        isDead = true;

        StageController.isDead = true;

        Audio audio = FindObjectOfType<Audio>();
        audio.DieSound();

        GameManager.instance.OnPlayerDead(); // 게임매니저의 OnPlayerDead 불러오기


    }
    private void Clear()
    {

        // 클리어 애니메이션
        charlieAnimator.SetTrigger("Clear");
        lionAnimator.SetTrigger("Clear");


        playerRigid.velocity = Vector2.zero;
        isDead = true;

        StageController.isDead = true;


        GameManager.instance.OnPlayerClear(); // 게임매니저의 OnPlayerClear 불러오기


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && isDead == false)
        {
            Debug.Log("플레이어 장애물과 만남");
            Die();
        }
        if (other.tag == "Clear" && isDead == false)
        {
            Debug.Log("플레이어 골대와 만남");
            Clear();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
