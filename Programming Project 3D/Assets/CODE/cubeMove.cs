using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{

    private Rigidbody rb;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>(); // calling other objects rigidbodies 
        
        PhysicMaterial boing = new PhysicMaterial("boing"); // physics material 

        boing.bounciness = 1.0f;

        boing.staticFriction = 0.3f;

        boing.dynamicFriction = 0.3f;

        GetComponent<Collider>().material = boing;
        
        if (rb.name == "cube")
        {
            rb.AddForce(Vector3.right * 20, ForceMode.Impulse);
        }

        if (rb.name == "cub")
        {
            rb.AddForce(Vector3.left * 20, ForceMode.Impulse);
        }
        
        if (rb.name == "cube2")
        {
            rb.AddForce(Vector3.down * 20, ForceMode.Impulse);
        }
        
        
    }
}
