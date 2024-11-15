using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PearlScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
}
