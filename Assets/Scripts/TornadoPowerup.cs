using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoPowerup : MonoBehaviour
{
    public GameObject closestKelpLeaf;

    private void Start()
    {
        // Find the closest kelp leaf relative to this powerup
        closestKelpLeaf = FindClosestKelp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SideTurtle")

        {
            ActivateTornadoPowerup();
        }
    }

    private GameObject FindClosestKelp()
    {
        GameObject[] kelpLeaves = GameObject.FindGameObjectsWithTag("Kelp");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector2 powerupPosition = transform.position;

        // Loop through all kelp leaves and find the closest one
        foreach (GameObject kelp in kelpLeaves)
        {
            float distanceToKelp = Vector2.Distance(powerupPosition, kelp.transform.position);

            // Check if this kelp is closer and located right after the powerup
            if (distanceToKelp < minDistance && kelp.transform.position.x > powerupPosition.x)
            {
                minDistance = distanceToKelp;
                closest = kelp;
            }
        }

        return closest;
    }

    private void ActivateTornadoPowerup()
    {
        // Destroy only the closest kelp leaf
        Debug.Log(closestKelpLeaf + "/before");
        if (closestKelpLeaf != null)
        {
            Destroy(closestKelpLeaf);
            Debug.Log(closestKelpLeaf + "/after");
        }

        // Destroy the powerup after it’s been used
        Destroy(gameObject);
    }
}
