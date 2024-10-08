
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages changing scenes/levels. Should be attached to a Canvas.
/// </summary>
/// <remarks>
/// Maintained by: Olivia StarStuff
/// </remarks>
public class SceneManagerScript : MonoBehaviour
{
    /// <summary>
    /// A wrapper to be used by buttons in the scene's UI
    /// </summary>
    /// <param name="sceneName">scene must be added to build settings</param>
    public static void LoadScene(string sceneName)
    {
        bool isLevel = SceneManager.GetActiveScene().name.StartsWith("Level");
        if(isLevel) {
            PlayerPrefs.SetInt("fromLevel", 1);
        }
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Self-explanatory. May not be useful for a mobile App.
    /// See https://docs.unity3d.com/ScriptReference/Application.Quit.html
    /// </summary>
    public static void QuitGame()
    {
        PlayerPrefs.SetInt("fromLevel", 0);
        Debug.Log("Quitting Application");
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set
            // to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public static void ReloadGame()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Load the level selector scene once clicked on the start button
    /// </summary>
    /// <remarks>
    /// Maintained by: Najaaz Nabhan
    /// </remarks>
    public void StartGame()
    {
        Debug.Log("Loading scene: LevelSelector");
        SceneManager.LoadScene("LevelSelection");
    }
}
