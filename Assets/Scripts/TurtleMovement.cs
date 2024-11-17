using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {

        SwipeManager.OnSwipe += HandleSwipe;
    }

    void OnDestroy()
    {
        SwipeManager.OnSwipe -= HandleSwipe;
    }

    void HandleSwipe(Vector2 swipeDirection)
    {
        float moveY = swipeDirection.y;

        transform.Translate(0f, moveY * moveSpeed * Time.deltaTime, 0f);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.name != "Powerups" && !GameManager.Instance.hasImmunity)
    //     {
    //         LevelOver();
    //     }

    // }

    // void LevelOver()
    // {
    //     Time.timeScale = 0f;
    // }
}