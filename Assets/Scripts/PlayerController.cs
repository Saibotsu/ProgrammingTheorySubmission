using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject mainCamera;
    private Vector3 cameraOffset = new Vector3(0, 5, -5);
    [SerializeField] float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }

    private void LateUpdate()
    {
        ProcessCamera();
    }

    private void ProcessMovement()
    {
        rb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed);
    }

    private void ProcessCamera()
    {
        mainCamera.transform.position = transform.position + cameraOffset;
    }


    public void HitPlayer(Obstacle obstacle)
    {
        Debug.Log("HitPlayer called");
        if(!obstacle.IsHit)
        {
            // Hurt the player
            Debug.Log("Obstacle IsHit=false and player hit and hurt");
        }
        else
        {
            Debug.Log("Obstacle IsHit=true and player hit, but no hurt");
        }
    }
}
