using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("fromLevel"));
        if (PlayerPrefs.GetInt("fromLevel") == 1)
        {
            SwitchMenu(GameObject.Find("LevelMenu"));
        }
    }
    public void SwitchMenu(GameObject page)
    {
        Debug.Log("Loading scene: LevelSelector");
        TransitionUI[] transitions = GetComponentsInChildren<TransitionUI>();
        TransitionUI targetPage = page.GetComponent<TransitionUI>();
        targetPage.TransitionIn();
        foreach (TransitionUI transition in transitions)
        {
            if (transition.gameObject != page)
            {
                transition.TransitionOut();
            }
        }
    }
}
