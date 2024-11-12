using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float[]pos;
    void Start()
    {

        for(int i = 0; i < outfits.Length; i++)
        {
            GameObject outfitBtn = Instantiate(outfitBtnTemplate,
                    transform.position,
                    Quaternion.identity,
                    transform);
            outfitBtn.name = "Outfit" + (i+1);
            outfitBtn.GetComponent<Image>().sprite = outfits[i].display;
            if (outfitBtn.name == PlayerPrefs.GetString("Outfit"))
            {
                outfitBtn.GetComponent<Toggle>().isOn = true;
                Debug.Log("Set toggle as selected");
            }
        }
    }
}
