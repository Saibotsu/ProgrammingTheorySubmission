using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private GameObject player;
    private Transform playerSpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerSpawnLocation = transform.GetChild(0);
        player.transform.position = playerSpawnLocation.position;
    }
}
