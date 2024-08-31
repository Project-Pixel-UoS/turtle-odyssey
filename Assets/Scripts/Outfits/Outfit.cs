using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

/// <summary>
/// Represents a turtle outfit
/// </summary>
/// <remarks>
/// Maintained by: Olivia Aurora
/// </remarks>
[CreateAssetMenu(fileName = "Outfit", menuName = "Outfit", order = 0)]
public class Outfit : ScriptableObject {
    public Sprite sprite;
    public AnimatorController controller;
}
