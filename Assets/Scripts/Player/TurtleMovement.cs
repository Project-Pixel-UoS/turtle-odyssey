using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SoundManager.Sfx moveSound = SoundManager.Sfx.SWOOSH;

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

        transform.Translate(0f, moveY * moveSpeed, 0f);
        GameManager.Instance.soundManager?.PlaySfx(moveSound);
    }
}