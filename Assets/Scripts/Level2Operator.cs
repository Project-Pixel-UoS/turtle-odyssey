using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the overall Level2 operations like swipe movements and collisions.
/// </summary>
/// <remarks>
/// Maintained by: Manya Mittal
/// </remarks>
public class Level2Operator : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public bool turtleMoves = true;
    public GameObject gameOver;
    public GameObject wellDone;
    void Update()
    {
        if (turtleMoves)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    private void Start()
    {
        SwipeManager.OnSwipe += HandleSwipe;
    }

    void OnDestroy()
    {
        SwipeManager.OnSwipe -= HandleSwipe;
    }

    void HandleSwipe(Vector2 swipeDirection)
    {
        float moveY = swipeDirection.y;
        transform.Translate(0f, moveY * 15f * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "FinishLine")

        {
            GameManager.Instance.GameWin();
            turtleMoves = false;
        }

        else if (collision.gameObject.CompareTag("Powerup"))
        {
            GameManager.Instance.BoostSpeed();
            turtleMoves = true;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("TornadoPowerup"))
        {
            turtleMoves = true;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.name == "PearlPickup")
        {
            GameManager.Instance.UpdatePearlScore();
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.name != "Powerups" && !GameManager.Instance.hasImmunity)
            {
                GameManager.Instance.GameOver();
                gameOver.SetActive(true);
                turtleMoves = false;

            }

        }

    }

    // public void RestartGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

}
