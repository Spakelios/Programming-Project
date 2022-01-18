using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    
    public void Start()
    {
        transform.Translate(Vector3.right);
    }

    private void Update()
    {
        transform.Translate(Vector3.right);
    }
}
