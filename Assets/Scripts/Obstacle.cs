using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public static float damage = 50f;
    public static float tempDamage = 50f;
    public static float speed,scalex,scaley;
    Vector3 position;
    bool inc = false;
    Collider Col;
    //public static bool col = false;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
        {
            if (Swipetool.pwr == false)
            {
                // ScoreManager.scoreValue += 10;
                FindObjectOfType<AudioManager>().Play("RockHit");
            }
            HealthManager.health -= damage;
            //  Debug.Log(Controller.health);           
            Destroy(gameObject);

        }
    }
    
    void Start()
    {
        //position = transform.position;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            speed = Levelinfo.obspeed1;
            scalex = transform.localScale.x;
            scaley = transform.localScale.y;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            speed = Levelinfo.obspeed2;
            scalex = -transform.localScale.x;
            scaley = transform.localScale.y;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            speed = Levelinfo.obspeed3;
            scalex = transform.localScale.x;
            scaley = transform.localScale.y;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            speed = Levelinfo.obspeed4;
            scalex = Levelinfo.obscalex4;
            scaley = Levelinfo.obscaley4;
        }
        position = transform.position;
        transform.localScale = new Vector2(scalex, transform.localScale.y);
        Col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && Swipetool.pwr == false)
        {
            if (PauseMenu.incr >= 20 && PauseMenu.incr < 50)
                speed = -8f;
            if (PauseMenu.incr >= 50 && PauseMenu.incr < 85)
                speed = -8.5f;
            if (PauseMenu.incr >= 85 && PauseMenu.incr < 120)
                speed = -9f;
            if (PauseMenu.incr >= 105 && PauseMenu.incr < 130)
                speed = -10f;
            if (PauseMenu.incr >= 130 && PauseMenu.incr < 155)
                speed = -12f;
            if (PauseMenu.incr >= 180)
                speed = -14f;
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
       /* if(transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }*/
    }
}
