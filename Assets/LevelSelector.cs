using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    /// <summary>
    /// Load the correct level scene based on what level the user wants.
    /// </summary>
    /// <remarks>
    /// Maintained by: Milan Zeki and Abdallah Khorma
    /// </remarks>
    public void LoadScene()
    {
        PlayerPrefs.SetInt("fromLevel", 0);
        SceneManager.LoadScene(sceneName: name);
    }
    public void LoadMyScene(GameObject me)
    {
        PlayerPrefs.SetInt("fromLevel", 0);
        SceneManager.LoadScene(sceneName: me.name);
    }
}
