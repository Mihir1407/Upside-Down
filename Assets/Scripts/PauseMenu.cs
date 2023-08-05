using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameEnded = false;
    public GameObject Powertutui;
    public GameObject pauseMenuUI;
    public GameObject endMenuUI;
    public GameObject lvlCompUI;
    public GameObject watchadui,watchmain,adwatchedui;
    public GameObject hert,revivebut;
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;
    public TextMeshProUGUI key;
    public HealthManager hm;
    public GameObject MainUI;
    public GameObject message;
    public static float timer, incr;
    float x, y, z;
    public GameObject am;
    public int temp;
    public static bool revivedonce = false;
    //AudioManager am = new AudioManager();
    // Start is called before the first frame update

    public void Start()
    {
        incr = 0;
        revivedonce = false;
        GameIsPaused = false;
        GameEnded = false;
    }

    public void pausegame()
    {
        if (!GameIsPaused)
        {
            pause();
        }
    }

    public void resume()
    {   if (message.activeSelf == true)
            message.SetActive(false);
        MainUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        am.SetActive(true);
        //   am.Resume(Controller.flag);
    }

    public void pause()
    {
        MainUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //am.DestroyIt();
        am.SetActive(false);
    }

    public void mainmenu()
    {
        MainUI.SetActive(true);
        GameIsPaused = false;
        GameEnded = false;
        //SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(0));
    }

    public void end()
    {
        
        Admanager.instance.ShowFullScreenAd();
        MainUI.SetActive(false);
        // FindObjectOfType<AudioManager>().Play("RockHit");
        endMenuUI.SetActive(true);
        if (revivedonce == true)
            revivebut.SetActive(false);
        GameEnded = true;
        textmeshPro.SetText("Score:" + PlayerPrefs.GetFloat("Score", 0).ToString());
        HighScore.updateHighScore();
        /*if ((PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp") >= 100))
        {
            x = PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp");
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0)+1);
            PlayerPrefs.SetFloat("LvlComp", x-100);
        }
        else if((PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp") < 100))
        {
            x = PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp");
            PlayerPrefs.SetFloat("LvlComp", x);
        }*/
        //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
        Time.timeScale = 0f;
        am.SetActive(false);
        Controller.flag = 0;

    }

    public void restart()
    {
        MainUI.SetActive(true);
        GameEnded = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));
        //Time.timeScale = 1f;
    }

    public void nextlvl()
    {
        MainUI.SetActive(true);
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex == 1)
            LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(2));
        //SceneManager.LoadScene(2);
        if (SceneManager.GetActiveScene().buildIndex == 2)
            LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(1));
        //SceneManager.LoadScene(1);
    }

    public void lvlcomp()
    {
        Admanager.instance.ShowFullScreenAd();
        lvlCompUI.SetActive(true);
        MainUI.SetActive(false);
        GameEnded = true;
        FindObjectOfType<AudioManager>().Play("LevelUp");
        textmeshPro2.SetText("Score:" + PlayerPrefs.GetFloat("Score", 0).ToString());

        /*if ((PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp") >= 100))
        {
            x = PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp");
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0)+1);
            PlayerPrefs.SetFloat("LvlComp", x-100);
        }
        else if((PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp") < 100))
        {
            x = PlayerPrefs.GetFloat("Score", 0) + PlayerPrefs.GetFloat("LvlComp");
            PlayerPrefs.SetFloat("LvlComp", x);
        }*/
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
        if (PlayerPrefs.GetInt("Level", 0) == 1)
            PlayGamesScript.UnlockAcheivement(GPGSIds.achievement_beginner);
        Time.timeScale = 0f;
        am.SetActive(false);
        Controller.flag = 0;
       
    }

    public void revive()
    {
        endMenuUI.SetActive(false);
        watchadui.SetActive(true);
    }

    public void usekey()
    {
        if (PlayerPrefs.GetInt("Key") > 0)
        {
            revivedonce = true;
            MainUI.SetActive(true);
            endMenuUI.SetActive(false);
            watchadui.SetActive(false);
            GameEnded = false;
            hm.enabled = true;
            hm.HealthHeart.overrideSprite = hm.red;
            Time.timeScale = 1f;
            PlayerPrefs.SetInt("Key", PlayerPrefs.GetInt("Key", 0) - 1);
            //hert.SetActive(true);
            HealthManager.health = 100f;
            am.SetActive(true);
        }
    }

    public void watchad()
    {
        Admanager.instance.ShowRewardedAd();
        //watchmain.SetActive(false);
        //adwatchedui.SetActive(true);
    }

    public void adrevive()
    {
        revivedonce = true;
        watchmain.SetActive(true);
        adwatchedui.SetActive(false);
        MainUI.SetActive(true);
        endMenuUI.SetActive(false);
        watchadui.SetActive(false);
        GameEnded = false;
        hm.enabled = true;
        hm.HealthHeart.overrideSprite = hm.red;
        Time.timeScale = 1f;
        //PlayerPrefs.SetInt("Key", PlayerPrefs.GetInt("Key", 0) - 1);
        //hert.SetActive(true);
        HealthManager.health = 100f;
        am.SetActive(true);
    }

    public void back()
    {
        endMenuUI.SetActive(true);
        watchadui.SetActive(false);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            if (!GameIsPaused)
            {
                timer = 0f;
                incr++;
                //Debug.Log(incr);
            }
        }

        if(Admanager.done == true)
        {
            watchmain.SetActive(false);
            adwatchedui.SetActive(true);
            Admanager.done = false;
        }
        key.SetText("X " + PlayerPrefs.GetInt("Key").ToString());
    }
}
