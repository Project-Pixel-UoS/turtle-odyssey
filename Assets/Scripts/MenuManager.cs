
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Start()
    {
        if (!PlayerPrefs.HasKey("levelUnlocked"))
        {
            PlayerPrefs.SetInt("levelUnlocked", 1);
            Debug.Log("Setting unlocked level to " + PlayerPrefs.GetInt("levelUnlocked"));
        }
        PlayerPrefs.SetInt("levelUnlocked", 5);
        Debug.Log(PlayerPrefs.GetInt("levelUnlocked"));
        if (PlayerPrefs.GetInt("fromLevel") == 1)
        {
            SwitchMenu(GameObject.Find("LevelMenu"));
        }
    }

    public void SwitchMenu(GameObject page)
    {
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

    public void SwitchMenuWithResume(GameObject page)
    {
        GameManager.Instance.Resume();
        SwitchMenu(page);
    }

    public void SwitchMenuWithPause(GameObject page)
    {
        GameManager.Instance.Pause();
        SwitchMenu(page);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("fromLevel");
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}
