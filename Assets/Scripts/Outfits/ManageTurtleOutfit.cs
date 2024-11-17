using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.U2D.Animation;

/// <summary>
/// Applies the selected outfit to the turtle object
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
public class ManageTurtleOutfit : MonoBehaviour
{
    SpriteRenderer outfitRenderer;
    Animator animator;
    public SerializableOutfit[] outfits;

    // Start is called before the first frame update
    void Start()
    {
        outfitRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        // PlayerPrefs.DeleteKey("Outfit");
        // PlayerPrefs.SetString("Outfit", "Outfit2");
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

    SerializableOutfit GetOutfit(string outfitName)
    {
        for (int i = 0; i < outfits.Length; i++)
        {
            if(outfits[i].name == outfitName)
            {
                return outfits[i];
            }
        }
        return null;
        // string assetGUID = AssetDatabase.FindAssets(outfitName)[0];
        // string path = AssetDatabase.GUIDToAssetPath(assetGUID);
        // return AssetDatabase.LoadAssetAtPath<Outfit>(path);
    }

    public void SetOutfit(string outfitName)
    {
        SerializableOutfit outfit = GetOutfit(outfitName);
        Debug.Log(outfit);
        Debug.Log("Wearing " + outfit.name);
        GetComponent<SpriteLibrary>().spriteLibraryAsset = outfit.outfit;
    }
}
