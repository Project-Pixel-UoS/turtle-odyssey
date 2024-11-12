using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Consolidates all stats used by the game in a GameManager Singleton
/// </summary>
public class GameManager : MonoBehaviour
{
    public float moveSpeed;
    public bool gameActive = true;
    private float savedSpeed;
    public float boostedSpeed;
    public GameObject gameButtons;
    public GameObject gameOverMenu;
    private static GameManager _instance;
    public AudioSource bgMusic;
    public bool hasImmunity = false;
    public GameObject WellDoneMenu;
    public bool isGamePaused = false;

    /// <summary>
    /// returns the GameManager
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.Log("GameManager does not exist in scene");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance is not null)
        {
            Destroy(_instance);
            Debug.Log("Replacing existing GameManager");
        }
        _instance = this;
    }

    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
        savedSpeed = moveSpeed;
    }

    public void GameOver()
    {
        bgMusic.Stop();
        gameActive = false;
        gameOverMenu.SetActive(true);
        // gameButtons.SetActive(false);
        Pause();

        // Time.timeScale = 0f;
    }

    public void Pause()
    {
        isGamePaused = true;
        savedSpeed = moveSpeed;
        moveSpeed = 0;
    }

    public void Resume()
    {
        isGamePaused = false;
        moveSpeed = savedSpeed;
    }

    public void BoostSpeed()
    {
        moveSpeed = boostedSpeed;
        StartCoroutine(ResetSpeedAfterDelay(8f)); // 8 seconds boost duration
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = savedSpeed;
    }

    public void GameWin()
    {
        Scene scene = SceneManager.GetActiveScene();
        int levelNumber = Int32.Parse(scene.name.Substring(5));
        Debug.Log("old unlocked Level is " + PlayerPrefs.GetInt("levelUnlocked"));
        if (PlayerPrefs.GetInt("levelUnlocked") <= levelNumber)
        {
            PlayerPrefs.SetInt("levelUnlocked", levelNumber+1);
        }
        Debug.Log("new unlocked Level is " + PlayerPrefs.GetInt("levelUnlocked"));
        WellDoneMenu.SetActive(true);
        Pause();
    }

}
