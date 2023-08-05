using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookAds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            FB.Init(() =>
            {
                FB.ActivateApp();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
