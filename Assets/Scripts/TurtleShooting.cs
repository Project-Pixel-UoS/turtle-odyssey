using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages how the turtle shoots bubbles
/// </summary>
/// <remarks>
/// Created by: Aashish and Abdullah
/// Maintained by: Manya Mittal and Olivia StarStuff
/// </remarks>
public class TurtleShooting : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public bool isBubblerActive = false;
    public int shotsRemaining = 0;
    private Coroutine currentRoutine;

    void Update()
    {
        if (isBubblerActive && Time.time >= nextFireTime)
        {
            ShootBubble();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public void EnableBubbleGun()
    {
        isBubblerActive = true;
        // shotsRemaining = 2;
    }

    public void DisableBubbleGun()
    {
        isBubblerActive = false;
    }

    private void ShootBubble()
    {
        // Instantiate the bubble prefab at the fire point position
        Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
        shotsRemaining--; // Decrease the shot counter each time a bubble is shot
    }

    public void ActivateBubbler(float powerupDuration)
    {
        // If the turtle take another powerup, the new timer should supercede
        // the old one.
        if (isBubblerActive)
        {
            Debug.Log("Disabling Coroutine");
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(BubblerTimer(powerupDuration));
    }

    // Moved the IEnumerator from BubbleProjectile.cs so it'll staay alive
    private IEnumerator BubblerTimer(float powerupDuration)
    {
        // Enable bubble shooting
        EnableBubbleGun();
        Debug.Log("waiting");

        // Wait for the duration of the powerup
        yield return new WaitForSeconds(powerupDuration);
        Debug.Log("Finished waiting");

        // Disable bubble shooting
        DisableBubbleGun();
    }
}
