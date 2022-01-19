using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera1Trigger : MonoBehaviour
{
  public GameObject roomCam;
  public GameObject anim;
  public GameObject hallCam;
  
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      roomCam.SetActive(false);
      hallCam.SetActive(true);
      anim.GetComponent<Animator>().Play("doorMovement");
    }
    else 
    {
      roomCam.SetActive(true);
      hallCam.SetActive(false);
    } 
      
  }
}
