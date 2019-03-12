﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
     public float threshold;
     public Transform playerSpawnPoint; //spawn point
     public GameObject player; //player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    { 
          if(player.transform.position.y < threshold)
          {
               player.transform.position = playerSpawnPoint.position;
          }
    }
}
