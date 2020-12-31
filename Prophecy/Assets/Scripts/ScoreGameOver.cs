using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{

    public Text results;
    void Start()
    {
        results.text = "You survived: " + TrackScore.score + " seconds.";
    }
}
