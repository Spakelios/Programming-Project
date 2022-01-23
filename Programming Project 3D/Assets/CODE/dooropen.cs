using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.GetComponent<Animator>().Play("DoorOpenowo");
        }
        else
        {
            transform.Translate(95, 2, 104);
        }
    }
}
