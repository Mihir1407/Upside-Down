using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private float damage = 20f;
    public static float speed, scalex, scaley;
    Vector3 position;
    //public static bool col = false;
    // Start is called before the first frame update

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            speed = Levelinfo.obspeed1;
            scalex = Levelinfo.endscale1;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            speed = Levelinfo.obspeed2;
            scalex = Levelinfo.endscale2;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            speed = Levelinfo.obspeed3;
            scalex = Levelinfo.endscale3;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            speed = Levelinfo.obspeed4;
            scalex = Levelinfo.endscale4;
        }
        position = transform.position;
        transform.localScale = new Vector2(scalex, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
}
