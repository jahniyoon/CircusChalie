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


    private Rigidbody2D playerRigid = default;
    private Animator animator = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (isDead == false)
        //{
        //    float xInput = Input.GetAxis("Horizontal");
        //    float xSpeed = xInput * speed;

        //    Vector2 newVelocity = new Vector2(xSpeed, playerRigid.velocity.y);
        //    playerRigid.velocity = newVelocity;
        //}
        if (isDead) { return; }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
        }
        //animator.SetBool("Grounded", isGrounded); //Ground �� �� ���� �ٿ��ֱ�� �ϴ� ���� �ϱ�.

    }
    private void Die()
    {
        playerRigid.velocity = Vector2.zero;
        playerRigid.AddForce(new Vector2(0, jumpForce));
        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead(); // ���ӸŴ����� OnPlayerDead �ҷ�����


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && isDead == false)
        {
            Debug.Log("�÷��̾� ��ֹ��� ����");
            Die();
        }

        //if (other.tag == "Score" && isDead == false)
        //{
        //    Debug.Log("�÷��̾� ���� ȹ��");
        //    GameManager.instance.AddScore(10);
        //}
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
