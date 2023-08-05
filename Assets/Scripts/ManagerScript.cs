using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{   public static ManagerScript Instance { get; private set; }
    public static int Counter { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void IncrementCounter()
    {
        Counter++;
    }

    public void RestartGame()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_hall_of_fame, Counter);
        Counter = 0;
    }
}
