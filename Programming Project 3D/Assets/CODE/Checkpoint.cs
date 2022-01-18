using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour

{
    public bool CheckpointReached;
    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.CompareTag("Player"))
        {
            Debug.Log("checkpoint!");
            CheckpointReached = true;
        }

    }
}