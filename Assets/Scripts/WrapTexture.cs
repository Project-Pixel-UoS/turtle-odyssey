using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Wraps a tiled material that is used in a MeshRenderer.
/// Material should use the unlit/texture shader.
/// </summary>
/// <remarks>
/// Maintained by: Olivia StarStuff
/// </remarks>
public class WrapTexture : MonoBehaviour
{
    public float offset = 0;
    public float moveSpeed = 5.0f;
    private Material material;

    /// <summary>
    /// If GameController exists, use its value for moveSpeed
    /// </summary>
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        if (GameManager.Instance) {
            moveSpeed = GameManager.Instance.moveSpeed;
        }
    }

    private void Update()
    {
        offset += (moveSpeed * Time.deltaTime)/transform.localScale.x;
        offset = Mathf.Repeat(offset, 1);
        material.mainTextureOffset = new Vector2(offset, 0);
    }
}
