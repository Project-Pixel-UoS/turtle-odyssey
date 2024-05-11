using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Consolidates all stats used by the game in a GameManager Singleton
/// </summary>
public class GameManager : MonoBehaviour
{
    public float moveSpeed;
    private static GameManager _instance;

    /// <summary>
    /// returns the GameManager
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.Log("GameManager does not exist in scene");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance is not null)
        {
            Destroy(_instance);
            Debug.Log("Replacing existing GameManager");
        }
        _instance = this;
    }
}