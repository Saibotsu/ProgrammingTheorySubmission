using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance - All obstacles save whether they hit the player already to avoid double hits by the obstacle
public class Obstacle : MonoBehaviour
{
    private bool isHit = false;
    //Encapsulation - Allowing to set IsHit to true, but not revert it back to false;
    public bool IsHit
    {
        set{ 
            if(value == true)
            {
                isHit = value;
            };
        }
        get{ return isHit; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().HitPlayer(this);
        }
        IsHit = true;
    }
}
