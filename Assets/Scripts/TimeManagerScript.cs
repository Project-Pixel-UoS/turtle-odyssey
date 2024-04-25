using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the timer of the level. Needs to be added to the text
/// </summary>
/// <remarks>
/// Maintained by: Manya Mittal
/// </remarks>
public class TimeManagerScript : MonoBehaviour   
{
    public float TimeRemaining;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;

    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn) 
        {
            if(TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                updatingTimer(TimeRemaining);
            }
            else 
            {
                TimeRemaining = 0;
                TimerOn = false;
            }
        }
    }

    void updatingTimer(float currentTime) 
    {
        if (TimerTxt != null)
        {
            currentTime += 1;
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }
}
