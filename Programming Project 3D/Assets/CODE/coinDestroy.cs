using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDestroy : MonoBehaviour
{
    public static int dropValue = 1;
    
    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManager.instance.ChangeScore(dropValue);
        }


    }
}