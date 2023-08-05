using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HighScoreUI;
    public GameObject ModeChooseUI;
    //public GameObject LvlUI;

    public void Start()
    {
        Admanager.instance.RequestBanner();
    }
    public void playgame ()
   {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //LvlUI.SetActive(true);
        Admanager.instance.HideBanner();
        ModeChooseUI.SetActive(true);
   }

   public void quitgame ()
   {
   		Application.Quit();
   }

    public void showHighScore()
    {
        HighScoreUI.SetActive(true);
    }

    public void OK()
    {
        HighScoreUI.SetActive(false);
    }

    public void lvl()
    {
        Admanager.instance.HideBanner();
        if (PlayerPrefs.GetInt("Level") % 2 == 0)
            LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(1));
        //SceneManager.LoadScene(1);
        else
            LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(2));
        //SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        ModeChooseUI.SetActive(false);

    }

    public void surv()
    {
        Admanager.instance.HideBanner();
        Time.timeScale = 1f;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(3));
        //SceneManager.LoadScene(3);
    }

    public void back()
    {
        Admanager.instance.RequestBanner();
        ModeChooseUI.SetActive(false);
    }
}
