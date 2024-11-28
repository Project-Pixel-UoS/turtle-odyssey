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
    public int numberOfPages;

    void Awake()
    {
        numberOfPages = (outfits.Length) % 3 > 0 ? 1 : 0;
        numberOfPages += outfits.Length/3;
    }
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

            outfitBtn.GetComponent<SetOutfit>().SetMyOutfit(outfits[i]);

            if (!isOutfitUnlocked(i))
            {
                Debug.Log(PlayerPrefs.GetInt("OutfitUnlockedFlags"));
                outfitBtn.GetComponent<Toggle>().interactable = false;
            }
            else
            {
                outfitBtn.GetComponent<SetOutfit>().SetUnlocked();
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

    public bool UnlockOutfit(int index)
    {
        return unlocker.UnlockOutfit(outfits[index]);
    }
}
