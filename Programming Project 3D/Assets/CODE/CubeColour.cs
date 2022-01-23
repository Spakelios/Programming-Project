using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColour : MonoBehaviour
{
    void Start()
    {

        PhysicMaterial bouncy = new PhysicMaterial("bouncy"); // physics material setting bouciness high and friction low to allow player to bounce 

        bouncy.bounciness = 1.0f;

        bouncy.staticFriction = 0.3f;

        bouncy.dynamicFriction = 0.7f;

        GetComponent<CapsuleCollider>().material = bouncy;

    }

    private void OnCollisionEnter(Collision other) // nested if statements - if the tag is x change colour to y
    {
        if (other.gameObject.CompareTag("bouncy"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
       else if (other.gameObject.CompareTag("boing"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (other.gameObject.CompareTag("bounce"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (other.gameObject.CompareTag("boi"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }
}
