using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the bubble throughout its duration
/// </summary>
/// <remarks>
/// Created by: Aashish and Abdullah
/// Maintained by: Manya Mittal and Olivia StarStuff
/// </remarks>
public class BubbleProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    private GameManager gm;
    public float currentTime = 0f;
    private void Start()
    {
        gm = GameManager.Instance;
        // Destroy the bubble after a set amount of time
        // Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Only simulate the bubble if game is not paused
        bool isTimePassing = gm.gameActive && !gm.isGamePaused;

        currentTime += isTimePassing ? Time.deltaTime : 0f;
        if (currentTime > lifetime)
        {
            Destroy(gameObject);
            return;
        }

        // Move the bubble forward (to the right)
        float currentSpeed = isTimePassing ? speed : 0f;
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            // Destroy the fish and the bubble on impact
            Destroy(collision.gameObject); // Destroy the fish
            Destroy(gameObject);           // Destroy the bubble
        }
    }
}
