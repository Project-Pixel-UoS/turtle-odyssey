using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Consolidates all stats used by the game in a GameManager Singleton
/// </summary>
/// <remarks>
/// Maintained by: Manya Mittal and Olivia StarStuff
/// </remarks>
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public AudioSource bgMusic;
    [Header("UI References")]
    public GameObject gameButtons;
    public GameObject gameOverMenu;
    public GameObject WellDoneMenu;
    public PearlScoreUI pearlScoreUI;
    SoundManager _soundManager;
    [Header("Game state")]
    public float moveSpeed;
    public float boostedSpeed;
    private float savedSpeed;
    public int pearlScore = 0;
    public bool hasImmunity = false;
    public bool gameActive = true;
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

    public SoundManager soundManager
    {
        get { return _soundManager; }
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
        pearlScore = PlayerPrefs.GetInt("PearlScore");
        pearlScoreUI = GameObject.Find("PearlScore").GetComponent<PearlScoreUI>();
        pearlScoreUI.UpdateScore(pearlScore);

        GameObject camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        _soundManager = camera.GetComponent<SoundManager>();
    }

    public void GameOver()
    {
        bgMusic.Stop();
        gameActive = false;
        gameOverMenu.SetActive(true);
        gameButtons.SetActive(false);
        _soundManager.PlaySfx(SoundManager.Sfx.FAIL);
        Pause();
    }

    public void Pause()
    {
        isGamePaused = true;

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
        if (PlayerPrefs.GetInt("maxLevel") > levelNumber &&
            PlayerPrefs.GetInt("levelUnlocked") <= levelNumber)
        {
            PlayerPrefs.SetInt("levelUnlocked", levelNumber+1);
        }
        gameActive = false;
        Debug.Log("new unlocked Level is " + PlayerPrefs.GetInt("levelUnlocked"));
        WellDoneMenu.SetActive(true);
        soundManager.PlaySfx(SoundManager.Sfx.WIN);
        Pause();
        PlayerPrefs.SetInt("PearlScore", pearlScore);
    }

    public void UpdatePearlScore()
    {
        pearlScore++;
        pearlScoreUI.UpdateScore(pearlScore);
    }
}
