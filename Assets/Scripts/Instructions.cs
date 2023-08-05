using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject Survbut;
    public GameObject Conlvlbut;
    public GameObject backbut;
    public GameObject helpbut;
    public GameObject okbut;
    public GameObject insttxt;
    // Start is called before the first frame update
   

    public void help()
    {
        Survbut.SetActive(false);
        Conlvlbut.SetActive(false);
        backbut.SetActive(false);
        helpbut.SetActive(false);
        okbut.SetActive(true);
        insttxt.SetActive(true);
    }

    public void ok()
    {
        Survbut.SetActive(true);
        Conlvlbut.SetActive(true);
        backbut.SetActive(true);
        helpbut.SetActive(true);
        okbut.SetActive(false);
        insttxt.SetActive(false);
    }


}
