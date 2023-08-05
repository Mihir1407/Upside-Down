using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip healthSound;
    public static AudioSource audioSrc;
    public GameObject upSound;
    public GameObject downSound;
    // Start is called before the first frame update
    void Start()
    {
        healthSound = Resources.Load<AudioClip>("Heal");

        audioSrc = GetComponent<AudioSource>();
    }

   

    public void PlaySound(string clip)
    {
        if (Time.timeScale == 1)
        {
            switch (clip)
            {
                case "Heal":
                    audioSrc.PlayOneShot(healthSound);
                    break;
                case "Upside":
                   // if (downSound.activeInHierarchy == true)
                        downSound.SetActive(false);
                    upSound.SetActive(true);
                    break;
                case "Downside":
                 //   if (upSound.activeInHierarchy == true)
                        upSound.SetActive(false);
                    downSound.SetActive(true);
                    break;

            }
        }
        if (Time.timeScale == 0)
        {switch (clip)
            { 
                case "Upside":
                    if (downSound.activeInHierarchy == true)
                        downSound.SetActive(false);
                    upSound.SetActive(false);
                break;
                case "Downside":
                    if (upSound.activeInHierarchy == true)
                        upSound.SetActive(false);
                    downSound.SetActive(false);
                    break;
            }
        }
    }
}
