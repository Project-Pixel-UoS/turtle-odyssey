using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the movement of obstacles. Needs to be attached to canvas.
/// </summary>
/// <remarks>
/// Maintained by: Manya Mittal
/// </remarks>
public class ObstacleSpawnerScript : MonoBehaviour
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
