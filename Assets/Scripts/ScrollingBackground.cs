using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingBackground : MonoBehaviour
{
    public static float bgSpeed;
    public Renderer bgRender;
    private float x;
    bool inc = false;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            bgSpeed = Levelinfo.bgspeed1;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            bgSpeed = Levelinfo.bgspeed2;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            bgSpeed = Levelinfo.bgspeed3;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            bgSpeed = Levelinfo.bgspeed4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && Swipetool.pwr == false)
        {
            if (PauseMenu.incr >= 60 && PauseMenu.incr < 90)
            {
                bgSpeed = 0.35f;
            }
            if (PauseMenu.incr >= 120 && PauseMenu.incr < 150)
            {
                bgSpeed = 0.4f;
            }
            if (PauseMenu.incr >= 180)
            {
                bgSpeed = 0.45f;
            }
        }
        if (Time.deltaTime <= 1 )
        {   
            bgRender.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
        }
       // Debug.Log(bgRender.material.mainTextureOffset);
    }
}
