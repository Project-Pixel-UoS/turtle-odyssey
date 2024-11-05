using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
