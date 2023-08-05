using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenu panelhandle;
    Image lvlimg;
    float maxlen = 100;
    public TextMeshProUGUI lvlperc;
    //public Button l1, l2, l3, l4;


    public void Start()
    {
        lvlimg = GetComponent<Image>();
        
        //lvlimg.fillAmount = PlayerPrefs.GetFloat("LvlComp", 0) / maxlen;
        lvlperc.SetText("Level " + ": " + PlayerPrefs.GetInt("Level", 0).ToString() );
        /*if(PlayerPrefs.GetInt("Level", 0) < 3)
        {
            l4.interactable = false;
            l3.interactable = false;
            l2.interactable = false;
        }
        else if(PlayerPrefs.GetInt("Level", 0) < 5)
        {
            l4.interactable = false;
            l3.interactable = false;
        }
        else if (PlayerPrefs.GetInt("Level", 0) < 7)
        {
            l4.interactable = false;
        }*/

    }

    /*public void lvl1()
    {
        SceneManager.LoadScene(1);
        panelhandle.LvlUI.SetActive(false);
    }

    public void lvl2()
    {
        SceneManager.LoadScene(2);
        panelhandle.LvlUI.SetActive(false);
    }

    public void lvl3()
    {
        SceneManager.LoadScene(3);
        panelhandle.LvlUI.SetActive(false);
    }

    public void lvl4()
    {
        SceneManager.LoadScene(4);
        panelhandle.LvlUI.SetActive(false);
    }*/

    public void Update()
    {
            /*if ((PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetFloat("LvlComp", 0)) < 100)
            {
                lvlimg.fillAmount = (PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetFloat("LvlComp", 0)) / maxlen;
                lvlperc.SetText("Level " + PlayerPrefs.GetInt("Level", 0).ToString() + " : " + (PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetFloat("LvlComp", 0)) + " %");
                PlayerPrefs.SetFloat("LvlComp", (PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetFloat("LvlComp", 0)));
            }
            if ((PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetInt("LvlComp", 0)) >= 100)
            {
                lvlimg.fillAmount = ((PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetInt("LvlComp", 0)) - 100) / maxlen;
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0));
                PlayerPrefs.SetFloat("LvlComp", (PlayerPrefs.GetInt("Score", 0) + PlayerPrefs.GetFloat("LvlComp", 0)) - 100);
                lvlperc.SetText("Level " + PlayerPrefs.GetInt("Level", 0).ToString() + " : " + PlayerPrefs.GetFloat("LvlComp", 0) + " %");
            }*/
        
    }
}
