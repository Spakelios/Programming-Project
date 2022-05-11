using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public GameObject battle;
    public GameObject battle2;
    public GameObject player;
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("robot"))
        {
            battle.SetActive(true);
            canvas.SetActive(false);
            Destroy(other.gameObject);
            player.SetActive(false);
        }
     
        if (other.CompareTag("big robot"))
        {
            battle2.SetActive(true);
            canvas.SetActive(false);
            Destroy(other.gameObject);
            player.SetActive(false);
        }

    }
}