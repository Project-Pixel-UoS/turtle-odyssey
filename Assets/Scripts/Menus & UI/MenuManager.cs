
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages menu transitions
/// </summary>
/// <remarks>
/// Maintained by: Olivia StarStuff
/// </remarks>
public class MenuManager : MonoBehaviour
{
    public bool IsSetLevelUnlocked;
    public int LevelUnlocked;
    public bool IsSetPearls;
    public int totalPearls;
    SoundManager soundManager;

    public void Awake()
    {
        if (IsSetLevelUnlocked) { PlayerPrefs.SetInt("levelUnlocked", LevelUnlocked); }
        if (IsSetPearls) { PlayerPrefs.SetInt("PearlScore", totalPearls); }

        if (!PlayerPrefs.HasKey("levelUnlocked"))
        {
            PlayerPrefs.SetInt("levelUnlocked", 1);
            Debug.Log("Setting unlocked level to " + PlayerPrefs.GetInt("levelUnlocked"));
        }
    }
    public void Start()
    {
        // Debug.Log(PlayerPrefs.GetInt("levelUnlocked"));
        // Debug.Log(PlayerPrefs.GetString("Outfit"));
        if (PlayerPrefs.GetInt("fromLevel") == 1)
        {
            SwitchMenu(GameObject.Find("LevelMenu"));
        }
        GameObject camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        soundManager = camera.GetComponent<SoundManager>();
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
        soundManager.PlaySfx(SoundManager.Sfx.SWOOSH);
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

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }
}
