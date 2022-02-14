using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PointMove : MonoBehaviour
{
    private Rigidbody _rb;
    private BallScript _ball;

    public float speedPoint = 30.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _ball = FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.4f)
        {
            transform.position = new Vector3(transform.position.x, 0.4f, 0.0f);
            _ball._angle = 9.0f;
        }
        if (transform.position.y > 14.61f)
        {
            transform.position = new Vector3(transform.position.x, 14.61f, 0.0f);
            _ball._angle = 45.0f;
        }
        if(transform.position.x < -15.0f)
            transform.position = new Vector3(-15.0f, transform.position.y, 0.0f);
        if(transform.position.x > 15.0f)
            transform.position = new Vector3(15.0f, transform.position.y, 0.0f);
        
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speedPoint * Time.deltaTime, Input.GetAxis("Vertical")* speedPoint * Time.deltaTime, 0));
        //change the angle of the ball shooting
        _ball._angle += Input.GetAxis("Vertical") * 0.25f;
    }
}
