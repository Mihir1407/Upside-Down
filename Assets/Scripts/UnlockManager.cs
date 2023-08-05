using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    public Button l1, l2, l3, l4;
    public Sprite act;
    // Start is called before the first frame update
    void Start()
    {
        l4.interactable = false;
        l3.interactable = false;
        l2.interactable = false;
        l1.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Level", 0) >= 3)
        {
            l2.interactable = true;
            l2.image.overrideSprite = act;
        }
        if(PlayerPrefs.GetInt("Level", 0) >= 5)
        {
            l3.interactable = true;
            l3.image.overrideSprite = act;
        }
        if (PlayerPrefs.GetInt("Level", 0) >= 7)
        {
            l4.interactable = true;
            l4.image.overrideSprite = act;
        }
    }
}
