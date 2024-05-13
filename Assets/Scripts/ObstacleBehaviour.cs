using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {
    public float moveSpeed = 5;
    public float deadZone = -20;
    public float leftEdge = 0;
    public float width = 0;

    void Start() {

        if (GameManager.Instance) {
            moveSpeed = GameManager.Instance.moveSpeed;
        }

        width = GetComponent<SpriteRenderer>().size.x;
        leftEdge = Screen.width*1080/Screen.height/200;
    }

    void Update() {
        if (GameManager.Instance) {
            moveSpeed = GameManager.Instance.moveSpeed;
        }
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.localPosition.x < -(width/2 + leftEdge)) {
            Destroy(gameObject);
        }
    }
}
