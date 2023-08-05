using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthHeart;
    public static float maxHealth = 100f;
    public static float health,low;
    public float CountInterval = 0.05f, timer = 0;
    public static float damageDown = 0.5f;
    public static float tempDamageDown = 0.5f;
    int Score = 500000, i = 0;
    public PauseMenu pm;
    private bool done;
    private Animator playerAnimation;
    public Sprite red, yellow;
    public GameObject msg,powertutui;
    // Start is called before the first frame update
    void Start()
    {
        HealthHeart = GetComponent<Image>();
        health = maxHealth;
        playerAnimation = GetComponent<Animator>();
        done = false;
        low = 0;
        HealthHeart.overrideSprite = red;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        HealthHeart.fillAmount = health / maxHealth;
        if (health <= 2)
        {
            //Destroy(gameObject);
            enabled = false;
            // Time.timeScale = 0f;
            powertutui.SetActive(false);
            pm.end();
        }

        if(Controller.side == 1)
        {
            timer += Time.deltaTime;
            playerAnimation.SetTrigger("dying");
            if (i < Score && timer >= CountInterval)
            {
                health = health - damageDown;
                timer = 0;
            }

            if (PlayerPrefs.GetInt("Level", 0) == 0)
            {
                if (done == false)
                {
                    //playerAnimation.SetTrigger("dying");
                    done = true;
                    StartCoroutine(msgdisp());
                }
            }
            if(health < 30 && low == 0)
            {   
                HealthHeart.overrideSprite = yellow;
                low = 1;
            }
            else if(health >= 30 && low==1)
            {
                HealthHeart.overrideSprite = red;
                low = 0;
            }
        }
        else
            playerAnimation.SetTrigger("undying");
    }

    IEnumerator msgdisp()
    {
        msg.SetActive(true);
        yield return new WaitForSeconds(3);
        msg.SetActive(false);
    }

}
