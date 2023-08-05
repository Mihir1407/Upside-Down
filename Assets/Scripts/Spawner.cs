using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;
    private float timeBtwSpawn;
    public float startTimeBtwSpwan;
    public float decreaseTime = 0f;
    public float minTime = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (PauseMenu.incr >= 4)
        {
            if (timeBtwSpawn <= 0)
            {
                if (SceneManager.GetActiveScene().buildIndex != 3)
                {
                    if (PauseMenu.incr <= 45)
                    {
                        int rand = Random.Range(0, obstaclePatterns.Length - 1);
                        Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
                        timeBtwSpawn = startTimeBtwSpwan;
                        if (startTimeBtwSpwan > minTime)
                        {
                            startTimeBtwSpwan -= decreaseTime;
                        }
                    }
                    else
                    {
                        Instantiate(obstaclePatterns[2], transform.position, Quaternion.identity);
                        enabled = false;
                    }
                }
                else
                {
                    int rand = Random.Range(0, obstaclePatterns.Length - 1);
                    Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpwan;
                    if (startTimeBtwSpwan > minTime)
                    {
                        startTimeBtwSpwan -= decreaseTime;
                    }
                }
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
}
