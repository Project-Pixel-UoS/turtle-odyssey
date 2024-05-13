using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Contains functions controlling buttons that appear in the popups when the level is completed or lost
/// </summary>
/// <remarks>
/// Maintained by: Milan Zeki
/// </remarks>
public class ButtonScriptLevelOne : MonoBehaviour
{


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

}