using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    public GameObject Finish;
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
            Finish.SetActive(true);
            turtleMoves = false;

        }
        else

        {
            GameManager.Instance.GameOver();
            gameOver.SetActive(true);
            turtleMoves = false; 
            
        }







    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}