using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMove : MonoBehaviour
{
    private Vector3 position;
    public float amplitude = 0.5f;
    public float frequency = 1;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_position = Vector3.up * amplitude * Mathf.Sin(frequency * Time.time);
        transform.localPosition = position + new_position;
    }
}
