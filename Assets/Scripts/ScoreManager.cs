using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{	public static int scoreValue = 0;
	Text score;
    public Image lvlimg;
    public float CountInterval = 0.05f, timer;
    public static int Score = 500000, i=1,incr;

    // Start is called before the first frame update
    void Start()
    {   
        score = GetComponent<Text>();
        lvlimg.fillAmount = 0f;
        PlayerPrefs.SetFloat("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //score.text = "Score: " + scoreValue;
        /*timer += Time.deltaTime;

        if (i < Score && timer >= CountInterval)
        {
            i++;
            score.text = "Score: " + i.ToString();
            timer = 0;
        }*/
        timer += Time.deltaTime;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (timer >= 1f)
            {
                if (!PauseMenu.GameIsPaused)
                {
                    timer = 0f;
                    incr++;
                    PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score", 0) + i);
                    lvlimg.fillAmount = 1f;
                    score.text = PlayerPrefs.GetFloat("Score", 0).ToString();
                }
            }
        }
        else
        {
            if (timer >= 1f)
            {
                if (!PauseMenu.GameIsPaused)
                {
                    timer = 0f;
                    incr++;
                    score.text =(PlayerPrefs.GetInt("Level", 0)+1).ToString();
                    //PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score", 0) + 1);
                    lvlimg.fillAmount = lvlimg.fillAmount + 0.02f;
                    //score.text = PlayerPrefs.GetFloat("Score", 0).ToString();
                }
            }
        }
        
    }

}

