using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanPoint : MonoBehaviour
{
    public GameObject[] obstacles;
    //private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
