using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Manages the overall outfit swipe operations and scaling for the scene
/// </summary>
/// <remarks>
/// Maintained by: Manya Mittal
/// </remarks>
public class OutfitSwipeManager : MonoBehaviour
{
    public SerializableOutfit[] outfits;
    public GameObject outfitBtnTemplate;
    public GameObject[] outfitButtons;
    public OutfitUnlocker unlocker;
    float[]pos;
    void Start()
    {
        int unlockedOutfits = PlayerPrefs.GetInt("OutfitUnlockedFlags");
        outfitButtons = new GameObject[outfits.Length];
        for(int i = 0; i < outfits.Length; i++)
        {
            GameObject outfitBtn = Instantiate(outfitBtnTemplate,
                    transform.position,
                    Quaternion.identity,
                    transform);
            outfitBtn.name = outfits[i].name;
            outfitBtn.GetComponent<Image>().sprite = outfits[i].display;
            if (outfitBtn.name == PlayerPrefs.GetString("Outfit"))
            {
                outfitBtn.GetComponent<Toggle>().isOn = true;
                Debug.Log("Set toggle as selected");
            }

            if (!isOutfitUnlocked(i)) {
                Debug.Log(PlayerPrefs.GetInt("OutfitUnlockedFlags"));
                outfitBtn.GetComponent<Toggle>().interactable = false;
            }
            else
            {
                outfitBtn.transform.GetChild(0).gameObject.SetActive(false);
            }
            outfitBtn.GetComponent<SetOutfit>().SetCost(outfits[i].cost);
            outfitButtons[i] = outfitBtn;
        }
    }

    bool isOutfitUnlocked(int index)
    {
        int unlockedOutfits = PlayerPrefs.GetInt("OutfitUnlockedFlags");

        return (unlockedOutfits & (1 << index)) != 0;
    }

    public void UnlockOutfit(int i)
    {
        if (unlocker.UnlockOutfit(outfits[i]))
        {
            outfitButtons[i].GetComponent<Toggle>().interactable = true;
            outfitButtons[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
