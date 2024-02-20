using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : Obstacle
{
    Vector3 startPosition;
    [SerializeField] float timeBeforeFalling = 3;
    [SerializeField] float fallSpeed = 1;
    private bool isFalling = false;
    private bool isGoingBack = false;
    private bool isOnStartPosition = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(StartFalling());
    }

    // Update is called once per frame
    void Update()
    {
        // Process the crushers movement by state. If state is falling, move it down.
        if(isFalling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        else if(isGoingBack)
        {
            // If the crusher is returning, move it up
            if(!isOnStartPosition)
            {
                transform.Translate(Vector3.up * fallSpeed * Time.deltaTime);
                IsOnStartPosition(); // Check the position - stop moving back if we reached the start position
            }
            else
            {
                isGoingBack = false;
                StartCoroutine(StartFalling());
            }
            
        }
        
    }

    IEnumerator StartFalling() // Using the coroutine to delay motions of the crusher
    {
        yield return new WaitForSeconds(timeBeforeFalling);
        isFalling = true;
        isOnStartPosition = false;
    }

    IEnumerator MoveToStartPosition()
    {
        yield return new WaitForSeconds(1);
        isGoingBack = true;
    }

    // Inheritance - Overriding the base OnCollisionEnter method with new behavior
    public override void OnCollisionEnter(Collision other)
    {
        // Inheritance/Polymorphism - calling the base method of the parent (responsible for managing player can be hit only once)
        base.OnCollisionEnter(other);
        isFalling = false;
        StartCoroutine(MoveToStartPosition());
    }

    // Abstraction - Providing a method to check whether the crusher has returned to where it was set in the game world
    private void IsOnStartPosition()
    {
        isOnStartPosition = (transform.position.y >= startPosition.y);
    }
}
