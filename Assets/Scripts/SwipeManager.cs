using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector2 touchStartPos;
    private bool isSwiping = false;

    public float swipeThreshold = 80f;

    public static event System.Action<Vector2> OnSwipe;

    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            isSwiping = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isSwiping = false;
        }
        #else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isSwiping = false;
            }
        }
        #endif

        if (isSwiping)
        {
            #if UNITY_EDITOR
            Vector2 currentTouchPos = Input.mousePosition;
            #else
            Vector2 currentTouchPos = Input.GetTouch(0).position;
            #endif

            Vector2 swipeDelta = currentTouchPos - touchStartPos;

            if (swipeDelta.magnitude > swipeThreshold)
            {
                OnSwipe?.Invoke(swipeDelta.normalized);
                isSwiping = false;
            }
        }
    }
}
