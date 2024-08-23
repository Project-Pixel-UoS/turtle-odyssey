using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls a page of buttons that lead to levels of the game.
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
public class LevelPage : MonoBehaviour
{
    public GameObject[] buttons;

    /// <summary>
    /// Sets the buttons details with given information.
    /// </summary>
    public void SetButton(int i, LevelButton button)
    {
        if (i < 0 || i >= buttons.Length)
        {
            return;
        }

        buttons[i].name = button.name;
        buttons[i].GetComponent<Image>().sprite = button.sprite;
        buttons[i].SetActive(true);
    }
}
