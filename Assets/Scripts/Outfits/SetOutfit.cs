using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

/// <summary>
/// Sets the turtle outfit state for the outfit selector button
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
public class SetOutfit : MonoBehaviour
{
    public void SelectOutfit()
    {
        PlayerPrefs.SetString("Outfit", gameObject.name);
        Debug.Log(PlayerPrefs.GetString("Outfit") + " has been set.");
    }

    public void UnlockOutfit()
    {

        GameObject parent = transform.parent.gameObject;
        int index = Int32.Parse(name.Substring(6))-1;
        parent.GetComponent<OutfitSwipeManager>().UnlockOutfit(index);
    }
    public void SetCost(int cost)
    {
        string plural = cost > 1 ? "s" : "";
        transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = cost + " Pearl" + plural;
    }
}
