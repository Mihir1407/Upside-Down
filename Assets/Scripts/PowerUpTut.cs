using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTut : MonoBehaviour
{
    public static bool powertutdone;
    public GameObject powtut;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        powertutdone = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(powertutdone == true)
        {
            StartCoroutine(msgdisp());
            powertutdone = false;
            enabled = false;
        }
            
    }

    IEnumerator msgdisp()
    {
        if (PauseMenu.GameIsPaused == false && PauseMenu.GameEnded == false)
        {
            powtut.SetActive(true);
            yield return new WaitForSeconds(3);
            powtut.SetActive(false);
        }
    }
}
