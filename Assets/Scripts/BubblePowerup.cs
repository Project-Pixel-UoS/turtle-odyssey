using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the bubble powerup's activation
/// </summary>
/// <remarks>
/// Created by: Aashish and Abdullah
/// Maintained by: Manya Mittal and Olivia StarStuff
/// </remarks>
public class BubblePowerup : MonoBehaviour
{
    public float powerupDuration = 10f; // Duration of the powerup
    private TurtleShooting turtleShooting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "SideTurtle") { return; }
        turtleShooting = collision.GetComponent<TurtleShooting>();
        if (turtleShooting != null)
        {
            turtleShooting.ActivateBubbler(powerupDuration);
        }
        // Disable the powerup object visually
        gameObject.SetActive(false);
    }
}
