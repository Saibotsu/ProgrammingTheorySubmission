using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance - All obstacles save whether they hit the player already to avoid double hits by the obstacle
public class RotateObject : Obstacle
{
    [SerializeField] private float speed = 120.0f;
    [SerializeField] private bool rotateClockwise = true;

    private void Start()
    {
        if(!rotateClockwise) // Switch the rotation direction of the rotator if the checkbox in the inspector is ticked
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
