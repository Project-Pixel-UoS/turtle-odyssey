using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShooting : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    private int shotsRemaining = 0;

    void Update()
    {
        if (shotsRemaining > 0 && Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootBubble();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public void EnableBubbleGun()
    {
        shotsRemaining = 2;
    }

    public void DisableBubbleGun()
    {
        shotsRemaining = 0;
    }

    private void ShootBubble()
    {
        // Instantiate the bubble prefab at the fire point position
        Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
        shotsRemaining--; // Decrease the shot counter each time a bubble is shot
    }
}
