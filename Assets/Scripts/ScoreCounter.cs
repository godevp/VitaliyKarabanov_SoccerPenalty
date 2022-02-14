using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text text;

    private BallScript ball;
    void Start()
    {
        ball = FindObjectOfType<BallScript>();
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = (ball.getPoints()).ToString();
    }
}
