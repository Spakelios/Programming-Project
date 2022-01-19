using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROOM3CAMTRIGGER : MonoBehaviour
{
    public GameObject hallCam;
    public GameObject roomCam3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hallCam.SetActive(false);
            roomCam3.SetActive(true);

        }
    }
}
