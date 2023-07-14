using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBlue : MonoBehaviour
{
    private Rigidbody2D monkeyRigid = default;
    private Animator animator = default;

    public float jumpForce = 300;
    private bool isJump = false;


    // Start is called before the first frame update
    void Start()
    {
        monkeyRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        monkeyRigid.gravityScale = 2.5f;

    }

    // Update is called once per frame
    void Update()
    {


        animator.SetBool("Jump", isJump); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Dead")
        {
            Debug.Log("¿ø¼þÀÌ Á¡ÇÁ ÁØºñ");
            monkeyRigid.velocity = Vector2.zero;
            monkeyRigid.AddForce(new Vector2(0, jumpForce));
        }
        if (other.tag == "PlayerPosition")
        {
            Debug.Log("¿ø¼þÀÌ »ç¸Á");

            gameObject.SetActive(false);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJump = true;

    }

}
