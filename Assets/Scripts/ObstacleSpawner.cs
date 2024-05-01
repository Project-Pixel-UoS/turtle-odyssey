using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Copy of ObstacleSpawnerScript from Level 2 created by Manya Mittal. Manages the movement of obstacles. Needs to be attached to canvas.
/// </summary>
/// <remarks>
/// Maintained by: Milan Zeki
/// </remarks>
public class ObstacleSpawner : MonoBehaviour // Changed the name of the class from ObstacleSpawnerScript to ObstacleSpawner
{
    public float moveSpeed = 0.75f;
    void Start()
    {

    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
