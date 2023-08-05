using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private float jumpSpeed = 8f;
    public static int side = 0;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public Animator playerAnimation;
    public PauseMenu gameEnd;
    public float speed = 200f;
    public static int flag=0;

    public GameObject powerUI;
    //SoundManagerScript sc = new SoundManagerScript();
    // public static int health = 3;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        side = 0;
        powerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        playerAnimation.SetBool("groundtouch", isTouchingGround);
       /* if(HealthManager.health <= 2)
        {
            playerAnimation.SetTrigger("dead");
        }*/
    }

    public void invert()
    {
        if (side == 0 && isTouchingGround)
        {
            playerAnimation.SetTrigger("change");
            transform.localScale = new Vector2(transform.localScale.x, -1.342001f);
            transform.position = new Vector2(transform.position.x, -1.06f);
            GetComponent<Rigidbody2D>().gravityScale = -1.5f;
            jumpSpeed = -1f * jumpSpeed;
            side = 1;
            if(Swipetool.pwr == true)
                playerAnimation.SetTrigger("powerup");
            else
                playerAnimation.SetTrigger("changedone");
            FindObjectOfType<AudioManager>().BackgroundPlay(1);
        }
        else if (side == 1 && isTouchingGround)
        {
            playerAnimation.SetTrigger("change");
            transform.localScale = new Vector2(transform.localScale.x, 1.342001f);
            transform.position = new Vector2(transform.position.x, 1.42f);
            GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            jumpSpeed = -1f * jumpSpeed;
            side = 0;
            if (Swipetool.pwr == true)
                playerAnimation.SetTrigger("powerup");
            else
                playerAnimation.SetTrigger("changedone");
            FindObjectOfType<AudioManager>().BackgroundPlay(0);
        }
    }

    public void jump()
    {   if(isTouchingGround)
        {
           
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obs"))
        {   if (Swipetool.pwr == false)
            {
                playerAnimation.SetTrigger("damage");
                playerAnimation.SetTrigger("DamDone");
            }

        }

        if (other.CompareTag("endsign"))
        {
            gameEnd.lvlcomp();
        }

    }
}
