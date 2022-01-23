using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROOM3CAMTRIGGER : MonoBehaviour
{
    public GameObject hallCam;
    public GameObject roomCam3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if player enters trigger
        { 
            hallCam.SetActive(false); // hall cam deactivates
            roomCam3.SetActive(true); // room 3 cam activates

        }
    }
}
