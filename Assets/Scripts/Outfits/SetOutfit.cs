using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public TextMeshProUGUI costLabel;
    public GameObject unlockButton;
    public void SelectOutfit()
    {
        PlayerPrefs.SetString("Outfit", gameObject.name);
        Debug.Log(PlayerPrefs.GetString("Outfit") + " has been set.");
    }

    public void UnlockOutfit()
    {

        GameObject parent = transform.parent.gameObject;
        int index = Int32.Parse(name.Substring(6))-1;
        if(parent.GetComponent<OutfitSwipeManager>().UnlockOutfit(index))
        {
            GetComponent<Toggle>().interactable = true;
            unlockButton.SetActive(false);
        }
    }
    public void SetCost(int cost)
    {
        string plural = cost > 1 ? "s" : "";
        costLabel.text = cost + " Pearl" + plural;
    }

    public void SetMyOutfit(SerializableOutfit outfit)
    {
        gameObject.name = outfit.name;
        Image outfitRenderer = transform.GetChild(0).GetComponent<Image>();
        Debug.Log(outfitRenderer);
        outfitRenderer.sprite = outfit.display;

        // is this outfit is active, set toggle
        if (gameObject.name == PlayerPrefs.GetString("Outfit"))
        {
            GetComponent<Toggle>().isOn = true;
            Debug.Log("Set toggle as selected");
        }
    }

    public void SetUnlocked()
    {
        unlockButton.SetActive(false);
    }
}
