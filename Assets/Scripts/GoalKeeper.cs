using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    private float moveX = 0;
    public float speed = 15.0f;
    public bool moveLeft = false;
    
    void Update()
    {
        if (moveLeft)
            moveX = 1.0f * speed * Time.deltaTime;
        else
            moveX = -1.0f * speed * Time.deltaTime;

        if (transform.position.x >= 7.89f)
            moveLeft = true;
        else if (transform.position.x <= -9.96f)
            moveLeft = false;

        if (transform != null) transform.Translate(new Vector3(moveX, 0, 0));
    }
}
