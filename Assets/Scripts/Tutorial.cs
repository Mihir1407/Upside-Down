using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutUI;
    public static bool tut;
    // Start is called before the first frame update
    void Start()
    {
        tut = false;
        tutUI.SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {   
        if (PauseMenu.incr >=2)
        {
            tutUI.SetActive(false);
        }
    }

}
