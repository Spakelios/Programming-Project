using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall2CamTrigger : MonoBehaviour
{
    public GameObject hallCam;
    public GameObject roomCam2;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hallCam.SetActive(true);
            roomCam2.SetActive(false);
            anim.GetComponent<Animator>().Play("DoorClose");
        }
        else 
        {
            roomCam2.SetActive(true);
            hallCam.SetActive(false);
        } 
    }
}
