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
    /// Maintained by: Milan Zeki
    /// </remarks>
    public void LoadScene()
    {
        switch (gameObject.name)
        {
            case "Level1":
                SceneManager.LoadScene(sceneName: "Level1");
                break;
            case "Level2":
                SceneManager.LoadScene(sceneName: "Level2");
                break;
            case "Level3":
                SceneManager.LoadScene(sceneName: "Level3");
                break;
            case "Level4":
                SceneManager.LoadScene(sceneName: "Level4");
                break;
            case "Level5":
                SceneManager.LoadScene(sceneName: "Level5");
                break;
        }
    }
}
