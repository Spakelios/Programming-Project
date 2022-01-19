using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Trigger : MonoBehaviour
{
    public GameObject hallCam;
    public GameObject roomcam2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hallCam.SetActive(false);
            roomcam2.SetActive(true);
        }
    }
}
