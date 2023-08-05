using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
 
    // Start is called before the first frame update
    void Start()
    {
        //textmeshPro.SetText("Highscore : "+PlayerPrefs.GetFloat("HighScore", 0).ToString());
    }

    public static void updateHighScore()
    {
        if(PlayerPrefs.GetFloat("Score", 0) > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", PlayerPrefs.GetFloat("Score", 0));
            PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_hall_of_fame, (int)PlayerPrefs.GetFloat("HighScore"));
            //textmeshPro.SetText("Highscore : " + PlayerPrefs.GetFloat("Score", 0).ToString());
        }
    }
    /*void Update()
    {
        if(PlayerPrefs.GetFloat("HighScore", 0)<PlayerPrefs.GetFloat("Score",0))
        {
            updateHighScore();
        }
    }*/
}
