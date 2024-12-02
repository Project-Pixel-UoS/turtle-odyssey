using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sfx { TOGGLE, FAIL, WIN, POWER_UP, SWOOSH, BUBBLES };
    public AudioSource player;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlaySfx()
    {
        player.Play();
    }

    public void PlaySfx(Sfx sfx)
    {
        // player.clip = clips[(int)sfx];
        player.PlayOneShot(clips[(int)sfx]);


    }
}
