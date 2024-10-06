using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BubbleProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    private void Start()
    {
        // Destroy the bubble after a set amount of time
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bubble forward (to the right)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
