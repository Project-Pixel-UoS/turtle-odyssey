using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates all pages and buttons for all levels of the game
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
public class LevelMenuManager : MonoBehaviour
{

    public LevelButton[] levels;
    public GameObject pageTemplate;
    public GameObject pageHolder;
    public int numberOfPages = 0;
    LevelPage page;

    void Awake()
    {
        for(int i = 0; i < levels.Length; i++)
        {
            if (i % 3 == 0) // 3 is arbitrary, 3 buttons per page.
            {
                GameObject pageObject = Instantiate(pageTemplate,
                        transform.position,
                        Quaternion.identity,
                        pageHolder.transform);
                pageObject.name = "Page" + (i / 3 + 1);
                page = pageObject.GetComponent<LevelPage>();
                numberOfPages++;
            }
            page.SetButton(i % 3, levels[i]);

        }
    }

    /// <summary>
    /// Counts how many levels are active. Unused for now.
    /// </summary>
    int CountActiveLevels()
    {
        int total = 0;
        foreach(LevelButton level in levels)
        {
            total += Convert.ToInt32(level.active);
        }
        return total;
    }

    public int GetNumberOfPages()
    {
        return LevelButtonToPage(levels.Length);
    }

    public int LevelButtonToPage(int buttonNumber)
    {
        return buttonNumber / 3 + Convert.ToInt32(buttonNumber % 3 > 0);
    }
}
