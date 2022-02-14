using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerLevel : MonoBehaviour
{
    private BallScript ball;
    private Text text;
   
    private void Awake()
    {
        text = GetComponent<Text>();
        ball = FindObjectOfType<BallScript>();
    }

    
    void Update()
    {
        text.text = "Power level: " + ball.power.ToString();
    }
}
