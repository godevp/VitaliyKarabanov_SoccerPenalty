using System;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    
    public float _angle = 25f;
    private Vector3 _startPos;
    public GameObject pointer;
    private Rigidbody _rb;
    private bool _startTimer;
    private float _timer;
    public float power;
    private int points;
    private GoalKeeper _goalKeeper;
    void Awake()
    {
        _startPos = transform.position;
        _rb = GetComponent<Rigidbody>();
        _goalKeeper = FindObjectOfType<GoalKeeper>();
        Reseting();
        points = 0;
    }

    //function for fast reset
    private void Reseting()
    {
        transform.position = _startPos;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _startTimer = false;
        _timer = 0;
        pointer.SetActive(true);
    }
    private void Update()
    {
        //check if we shoot into the gate or not
        if (transform.position.z >= 2.0f && transform.position.x >= -12.2f && transform.position.x <= 10.3 &&
            transform.position.y <= 8.0f)
        {
            Reseting();
            points++;
            _goalKeeper.speed += 1.5f;
        }
        else if (transform.position.z >= 2.0f && (transform.position.x < -12.2f || transform.position.x > 10.3) || 
                 transform.position.y > 8.0f)
        {
            Reseting();
            points = 0;
            _goalKeeper.speed = 15.0f;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (power > 5.0f)//
            power = 5.0f;//  minumum and maximum for power
        if (power < 1.0f)//
            power = 1.0f;//
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //start timer so it will reset everything automatically after some time
        if (_startTimer)
        {
            _timer += Time.deltaTime;
            if (_timer >= 7.0f)
            {
                Reseting();
                points = 0;
                _goalKeeper.speed = 15.0f;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //our input and shooting
        if (Input.GetKeyDown(KeyCode.Space) && !_startTimer)
        {
            FireCannonAtPoint(pointer.transform.position);
            _startTimer = true;
            pointer.SetActive(false);
        }
        transform.eulerAngles = new Vector3(0f,0f,90f-_angle);
    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, _angle);
        _rb.velocity = velocity * power * 0.3f;
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - _startPos; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized ; // Return a normalized vector.
        
        // Vy = V * sin(theta)??
        // Vz = V * cos(theta) in lecture Vx = V * cos(theta);
        // Vx = ?????????????
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if we collide with the goalkeeper
        if (collision.gameObject.name == "SoccerPlayer")
        {
            Reseting();
            points = 0;
            _goalKeeper.speed = 15.0f;
        }
    }
    
    //just a getter for points
    public int getPoints()
    {
        return points;
    }
    
    //GUI
    public void OnGUI()
    {
        power = GUI.HorizontalSlider (new Rect (1194, 800, 100, 30), power, 1.0f, 5.0f);
        if (GUI.Button (new Rect (1194, 700, 100, 30), "Reset")) 
        {
          Reseting();
          points = 0;
          _goalKeeper.speed = 15.0f;
          power = 5.0f;
        }
    }
}