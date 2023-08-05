using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaclepos : MonoBehaviour
{
   // private float damage = 20f;
    public static float speed = 3;
    bool inc = false;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ScoreManager.scoreValue += 10;
            if (HealthManager.health < 100)
            HealthManager.health += 20f;
            FindObjectOfType<AudioManager>().Play("Heal");
            //  Debug.Log(Controller.health);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            speed = Levelinfo.obspeed1;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            speed = Levelinfo.obspeed2;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            speed = Levelinfo.obspeed3;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            speed = Levelinfo.obspeed4;
        }
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
    }
}
