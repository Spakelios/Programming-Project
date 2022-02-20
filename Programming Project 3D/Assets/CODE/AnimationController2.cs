using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class AnimationController2 : MonoBehaviour
{
    public Animator anim;
    private float Velocity = 0.0f;
    public float accelleration = 0.1f;
    public float decelleration = 0.5f;
    private int VelocityHash;

    void Start()
    {
        anim = GetComponent<Animator>();

        VelocityHash = Animator.StringToHash("Velocity");
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("q");

        if (forwardPressed && Velocity < 5)
        {
            Velocity += Time.deltaTime * accelleration;
        }

        if (!forwardPressed && Velocity > 0)
        {
            Velocity -= Time.deltaTime * decelleration;
        }

        if (!forwardPressed && Velocity < 0.1f)
        {
            Velocity = 0.0f;
        }
        
        anim.SetFloat(VelocityHash, Velocity);
    }
}