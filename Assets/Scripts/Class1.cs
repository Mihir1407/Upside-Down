using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class1 : MonoBehaviour
{

    public float jumpSpeed = 4f;
    public static int side = 0;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    private Animator playerAnimation;
    // public static int health = 3;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        side = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        /* if (Input.GetButtonDown("Invert"))
         {
             if (side == 0 && isTouchingGround)
             {
                 transform.localScale = new Vector2(1.342001f, -1.342001f);
                 transform.position = new Vector2(-1.63f, -1.32f);
                 GetComponent<Rigidbody2D>().gravityScale = -1;
                 jumpSpeed = -1f * jumpSpeed;
                 side = 1;
             }
             else if (side == 1 && isTouchingGround)
             {
                 transform.localScale = new Vector2(1.342001f, 1.342001f);
                 transform.position = new Vector2(-1.63f, 1.26f);
                 GetComponent<Rigidbody2D>().gravityScale = 1;
                 jumpSpeed = -1f * jumpSpeed;
                 side = 0;
             }
         }
         if (Input.GetButtonDown("Jump") && isTouchingGround)
         {
             rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
         }*/
        playerAnimation.SetBool("groundtouch", isTouchingGround);
    }

    public void invert()
    {
        if (side == 0 && isTouchingGround)
        {
            transform.localScale = new Vector2(1.342001f, -1.342001f);
            transform.position = new Vector2(-1.63f, -0.94f);
            GetComponent<Rigidbody2D>().gravityScale = -1;
            jumpSpeed = -1f * jumpSpeed;
            side = 1;
        }
        else if (side == 1 && isTouchingGround)
        {
            transform.localScale = new Vector2(1.342001f, 1.342001f);
            transform.position = new Vector2(-1.63f, 1.26f);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            jumpSpeed = -1f * jumpSpeed;
            side = 0;
        }
    }

    public void jump()
    {
        if (isTouchingGround)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
    }
}
