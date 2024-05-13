using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionUI : MonoBehaviour
{
    private RectTransform rect;
    public Vector2 originalPosition;
    private bool isTransition = false;
    private Vector2 currentPosition;
    private Vector2 targetPosition;
    public float smoothTime = 0.3F;
    private Vector2 velocity = Vector2.zero;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        // originalPosition = rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransition)
        {
            Vector2 newPosition = Vector2.SmoothDamp(rect.anchoredPosition,
                    targetPosition, ref velocity, smoothTime);
            rect.anchoredPosition = newPosition;
            if (newPosition ==  Vector2.zero)
            {
                Debug.Log("Transition complete");
                isTransition = false;
            }
        }
    }

    public void TransitionIn()
    {
        targetPosition = Vector2.zero;
        isTransition = true;
    }

    public void TransitionOut()
    {
        targetPosition = originalPosition;
        isTransition = true;
    }
}
