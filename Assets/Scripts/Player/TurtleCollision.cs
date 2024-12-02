using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the overall Level2 operations like swipe movements and collisions.
/// </summary>
/// <remarks>
/// Maintained by: Manya Mittal
/// </remarks>
public class TurtleCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "FinishLine")

        {
            GameManager.Instance.GameWin();
        }

        else if (collision.gameObject.CompareTag("Powerup"))
        {
            GameManager.Instance.BoostSpeed();
            // GameManager.Instance.soundManager?.PlaySfx(SoundManager.Sfx.POWER_UP);
            Destroy(collision.gameObject);

        }

        else if (collision.gameObject.CompareTag("TornadoPowerup"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.soundManager.PlaySfx(SoundManager.Sfx.POWER_UP);
        }

        else if (collision.gameObject.name == "PearlPickup")
        {
            GameManager.Instance.UpdatePearlScore();
            Destroy(collision.gameObject);
            GameManager.Instance.soundManager.PlaySfx(SoundManager.Sfx.POWER_UP);
        }
        else
        {
            if (collision.gameObject.name != "Powerups" && !GameManager.Instance.hasImmunity)
            {
                GameManager.Instance.GameOver();
            }

        }
    }
}
