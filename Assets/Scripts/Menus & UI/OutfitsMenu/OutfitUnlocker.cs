using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutfitUnlocker : MonoBehaviour
{
    public int pearlScore = 0;
    public PearlScoreUI pearlScoreUI;
    public OutfitSwipeManager outfitSwipeManager;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("OutfitUnlockedFlags") == 0)
        {
            PlayerPrefs.SetInt("OutfitUnlockedFlags", 1);
        }
        // PlayerPrefs.SetInt("PearlScore", 5);
        Debug.Log(PlayerPrefs.GetInt("OutfitUnlockedFlags"));
    }
    void Start()
    {

        pearlScore = PlayerPrefs.GetInt("PearlScore");
        pearlScoreUI.UpdateScore(pearlScore);
    }

    public bool UnlockOutfit(SerializableOutfit outfit)
    {
        if (pearlScore - outfit.cost >= 0)
        {
            pearlScore -= outfit.cost;
            PlayerPrefs.SetInt("PearlScore", pearlScore);
            pearlScoreUI.UpdateScore(pearlScore);

            int unlockedOutfits = PlayerPrefs.GetInt("OutfitUnlockedFlags");
            int outfitIndex = Int32.Parse(outfit.name.Substring(6));
            unlockedOutfits = unlockedOutfits | (1 << outfitIndex-1);
            PlayerPrefs.SetInt("OutfitUnlockedFlags", unlockedOutfits);
            return true;
        }
        return false;
    }
}
