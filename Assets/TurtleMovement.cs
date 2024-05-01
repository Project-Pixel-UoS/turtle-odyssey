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
}