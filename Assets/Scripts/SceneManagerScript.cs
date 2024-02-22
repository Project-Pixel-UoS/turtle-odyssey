using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public static void Quit() {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}
