using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackScore : MonoBehaviour
{

    public Text survivedText;

    public static float score;

    void Start()
    {
        score = 0;
        survivedText.text = "Time survived: " + score;
    }

    void Update()
    {
        score += Time.deltaTime;
        survivedText.text = "Time survived: " + score;
    }
}
