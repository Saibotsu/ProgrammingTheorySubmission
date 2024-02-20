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

    // Abstraction - Processing player input to control the player object
    private void ProcessMovement()
    {
        rb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed);
    }

    // Abstraction - Setting the camera position so it follows the player when navigating the level
    private void ProcessCamera()
    {
        mainCamera.transform.position = transform.position + cameraOffset;
    }

    /* Hitting the player and providing a reference to the base class
       Using the reference we check whether we hit the obstacle for the first time */ 
    public void HitPlayer(Obstacle obstacle)
    {
        if(!obstacle.IsHit)
        {
            GameManager.Instance.IncreaseScore(1);
        }
        else
        {
            Debug.Log("Obstacle IsHit=true and player hit, but no hurt");
        }
    }
}
