using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using TMPro;

public class PlayGamesScript : MonoBehaviour
{
    // Start is called before the first frame update
    //private static bool signedin = false;
    public TextMeshProUGUI textlog;
    void Start()
    {
           
           PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
           PlayGamesPlatform.InitializeInstance(config);
           PlayGamesPlatform.Activate();
        textlog.SetText("LOGGING IN!");
        SignIn();
        
        
    }

    void SignIn()
    {
        Social.localUser.Authenticate(success => { });
        
        //signedin = true;
    }

    #region Acheivements
    public static void UnlockAcheivement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAcheivement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public static void showAcheivementsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId,long score)
    {   
        Social.ReportScore(score, leaderboardId, sucess => { });
    }

    public static void showLeadboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion

    public void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            textlog.SetText("NO CONNECTION!");
        }
        else if (Social.localUser.authenticated == true)
        {
            textlog.SetText("LOGIN SUCCESSFUL!");

        }
    }
}
