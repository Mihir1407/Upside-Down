using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmover : MonoBehaviour
{
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        //position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 13f * Time.deltaTime);
    }
}
