using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    private Text text;
    private int bestScore;
    private BallScript ball;
    void Start()
    {
        ball = FindObjectOfType<BallScript>();
        text = GetComponent<Text>();
        bestScore = 0;
    }
    void Update()
    {
        if (bestScore < ball.getPoints())
        {
            bestScore = ball.getPoints();
            text.text = bestScore.ToString();
        }
    }
}
