using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{   
    public static UIScript Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void GetPoint()
    {
        ManagerScript.Instance.IncrementCounter();
    }

    public void Restart()
    {
        ManagerScript.Instance.RestartGame();
    }

    public void Increment()
    {
        PlayGamesScript.IncrementAcheivement(GPGSIds.achievement_beginner, 5);
    }

    // Update is called once per frame
    public void ShowAchievements()
    {
        PlayGamesScript.showAcheivementsUI();
    }

    public void ShowLeaderboards()
    {
        PlayGamesScript.showLeadboardsUI();
    }

    public void Unlock()
    {
        PlayGamesScript.UnlockAcheivement(GPGSIds.achievement_beginner);
    }
}
