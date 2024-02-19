using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float speed = 120.0f;
    [SerializeField] private bool rotateClockwise = true;

    private void Start()
    {
        if(!rotateClockwise)
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
