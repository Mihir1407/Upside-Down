using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsScore : MonoBehaviour
{
    // private float damage = 20f;
    public static float speed = 3;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ScoreManager.scoreValue += 10;
            PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score", 0) + 10);
            //FindObjectOfType<AudioManager>().Play("Heal");
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
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
