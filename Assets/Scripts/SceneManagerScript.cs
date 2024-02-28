
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
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Self-explanatory. May not be useful for a mobile App.
    /// See https://docs.unity3d.com/ScriptReference/Application.Quit.html
    /// </summary>
    public static void QuitGame()
    {
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
}
