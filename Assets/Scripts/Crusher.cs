using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
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
        if(isFalling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        else if(isGoingBack)
        {
            if(!isOnStartPosition)
            {
                IsOnStartPosition();
                transform.Translate(Vector3.up * fallSpeed * Time.deltaTime);
            }
            else
            {
                isGoingBack = false;
                StartCoroutine(StartFalling());
            }
            
        }
        
    }

    IEnumerator StartFalling()
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

    private void OnTriggerEnter(Collider other)
    {
        isFalling = false;
        StartCoroutine(MoveToStartPosition());
    }

    private void IsOnStartPosition()
    {
        isOnStartPosition = (transform.position.y >= startPosition.y);
    }
}
