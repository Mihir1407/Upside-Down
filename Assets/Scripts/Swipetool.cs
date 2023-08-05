using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Swipetool : MonoBehaviour 
{
	
	private float minSwipeDistY = 150;
    private float minSwipeDistX = 150;

    private Vector2 startPos;

    public Controller swipeController;
    public static bool pwr = false;
    float swipeValue,ogobspeed,ogbackspeed;
    private bool powerFlag = false;

    private void Start()
    {
        pwr = false;
        powerFlag = false;
    }
    void Update()
	{
//#if UNITY_ANDROID
		if (Input.touchCount > 0) 
			
		{
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) 
				
			{
				
			case TouchPhase.Began:

				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:

					float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistVertical >= swipeDistHorizontal)
                    {
                        if (swipeDistVertical >= minSwipeDistY)
                        {
                            swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                            if (swipeValue > 0)//up swipe
                            {
                                if (Controller.side == 1)
                                {
                                    swipeController.invert();
                                }
                                else if (Controller.side == 0)
                                {
                                    swipeController.jump();
                                }
                                //Jump ();
                            }

                            else if (swipeValue < 0)//down swipe

                            {
                                if (Controller.side == 0)
                                {
                                    swipeController.invert();
                                }
                                else if (Controller.side == 1)
                                {
                                    swipeController.jump();
                                }
                            }
                        }
                    }

                    else
                    {

                        if (swipeDistHorizontal >= minSwipeDistX)

                        {

                            swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                            if (swipeValue > 0 && SceneManager.GetActiveScene().buildIndex%2 != 0)//right swipe

                            {   
                                if(pwr == false)
                                    if(powerFlag)
                                        {
                                            StartCoroutine(power());  
                                            powerFlag = false;
                                        // powerUI.SetActive(false);
                                        swipeController.powerUI.SetActive(false);
                                        
                                    }
                                                                
                            }

                            if (swipeValue < 0 && SceneManager.GetActiveScene().buildIndex % 2 == 0)//right swipe

                            {
                                if (pwr == false)
                                    if (powerFlag)
                                    {
                                        StartCoroutine(power());
                                        powerFlag = false;
                                        // powerUI.SetActive(false);
                                        swipeController.powerUI.SetActive(false);

                                    }

                            }

                        }
                    }
                    break;
			}
		}

        if(PowerPos.cldid == true && pwr==false)
        {
          //  StartCoroutine(power());
            powerFlag = true;
            //powerUI.SetActive(true);
            swipeController.powerUI.SetActive(true);
           //bstacle.damage = 0f;
        }
	}

    IEnumerator power()
    {
        swipeController.playerAnimation.SetTrigger("powerup");
        pwr = true;
        ogobspeed = Obstacle.speed;
        ogbackspeed = ScrollingBackground.bgSpeed;
        Obstacle.damage = 0f;
        Obstacle.speed = Obstacle.speed * 100f;
        Obstaclepos.speed = Obstaclepos.speed * 100f;
        PowerPos.speed = PowerPos.speed * 100f;
        ScrollingBackground.bgSpeed = ScrollingBackground.bgSpeed * 3f;
        ScoreManager.i = 10;
        HealthManager.damageDown = 0f;
        yield return new WaitForSeconds(5);
        pwr = false;
        PowerPos.cldid = false;
        Obstacle.damage = 50f;
        Obstacle.speed = ogobspeed;
        Obstaclepos.speed = ogobspeed;
        PowerPos.speed = ogobspeed;
        ScrollingBackground.bgSpeed = ogbackspeed;
        ScoreManager.i = 1;
        swipeController.playerAnimation.SetTrigger("powerdown");
        HealthManager.damageDown = HealthManager.tempDamageDown;
    }

    /*public void powerUps()
    {
        StartCoroutine(power());
    }*/
}