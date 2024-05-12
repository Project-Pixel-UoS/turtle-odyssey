using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    public GameObject Background;
    public float spawnRate = 5;
    private float timer = 0;

    void Start()
    {
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(Background, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
