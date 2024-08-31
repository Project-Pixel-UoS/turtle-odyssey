using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Applies the selected outfit to the turtle object
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
public class ManageTurtleOutfit : MonoBehaviour
{
    public Outfit outfit;

    SpriteRenderer outfitRenderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        outfitRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //PlayerPrefs.DeleteKey("Outfit");

        string outfitName = PlayerPrefs.GetString("Outfit");
        if (outfitName == "") {
            PlayerPrefs.SetString("Outfit", "Outfit1");
        }
        else
        {
            SetOutfit(outfitName);
        }

        // foreach (string s in AssetDatabase.FindAssets("l:Outfits"))
        // {
        //     Debug.Log(AssetDatabase.GUIDToAssetPath(s));
        // }
    }

    Outfit GetOutfit(string outfitName)
    {
        string assetGUID = AssetDatabase.FindAssets(outfitName)[0];
        string path = AssetDatabase.GUIDToAssetPath(assetGUID);
        return AssetDatabase.LoadAssetAtPath<Outfit>(path);
    }

    public void SetOutfit(string outfitName)
    {
        outfit = GetOutfit(outfitName);
        outfitRenderer.sprite = outfit.sprite;
        animator.runtimeAnimatorController = outfit.controller;
    }
}
