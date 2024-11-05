using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePowerup : MonoBehaviour
{
    public float powerupDuration = 10f; // Duration of the powerup
    private TurtleShooting turtleShooting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SideTurtle")
        {
            turtleShooting = collision.GetComponent<TurtleShooting>();
            if (turtleShooting != null)
            {
                StartCoroutine(ActivateBubblePowerup());
            }
            // Disable the powerup object visually
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ActivateBubblePowerup()
    {
        // Enable bubble shooting
        turtleShooting.EnableBubbleGun();

        // Wait for the duration of the powerup
        yield return new WaitForSeconds(powerupDuration);

        // Disable bubble shooting
        turtleShooting.DisableBubbleGun();

        // Destroy the powerup object
        Destroy(gameObject);
    }
}
