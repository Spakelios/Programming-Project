using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall2CamTrigger : MonoBehaviour
{
    public GameObject hallCam;
    public GameObject roomCam2;
    public Animator anim;
    public GameObject spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if player enters collider
        {
            hallCam.SetActive(true); // hall cam activates
            roomCam2.SetActive(false); // room cam deactivates
            anim.GetComponent<Animator>().Play("DoorClose"); // animation plays
            spawner.SetActive(false); // spawner deactivates 
            
        }
        else // if nothing enters the collider
        {
            roomCam2.SetActive(true); // room cam is active
            hallCam.SetActive(false); // hall cam is not active
            spawner.SetActive(true); // spawner is active
        } 
    }
}
