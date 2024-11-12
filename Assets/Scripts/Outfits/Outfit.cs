using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

/// <summary>
/// Represents a turtle outfit
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
[CreateAssetMenu(fileName = "Outfit", menuName = "Outfit", order = 0)]
public class Outfit : ScriptableObject {
    public SerializableOutfit values;
}

[System.Serializable]
public class SerializableOutfit {
    public string name;
    public Sprite display;
    public SpriteLibraryAsset outfit;
}