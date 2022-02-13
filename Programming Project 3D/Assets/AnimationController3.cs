using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController3 : MonoBehaviour
{
  public Animator anim;
  float velocityZ = 0.0f;
   float velocityX = 0.0f;
   public float accelleration = 2.0f;
   public float decelleration = 2.0f;
   public float maximumVelocity = 0.5f;
   public float maximumRunVelocity = 2.0f;
  
   
  private void Start()
  {
    anim = GetComponent<Animator>();
  }

  private void Update()
  {
    bool forwardPressed = Input.GetKey("w");
    bool rightPressed = Input.GetKey("a");
    bool leftPressed = Input.GetKey("d");
    bool runPressed = Input.GetKey("left shift");

    //set current maxVelocity
    float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumVelocity;

    if (forwardPressed && velocityZ < currentMaxVelocity)
    {
      velocityZ += Time.deltaTime * accelleration;
    }

    if (leftPressed && velocityX > -currentMaxVelocity)
    {
      velocityX -= Time.deltaTime * accelleration;
    }

    if (rightPressed && velocityX < currentMaxVelocity)
    {
      velocityX += Time.deltaTime * accelleration;
    }

    if (!forwardPressed && velocityZ > 0.0f)
    {
      velocityZ -= Time.deltaTime * decelleration;
    }

    if (!forwardPressed && velocityZ < 0.0f)
    {
      velocityZ = 0.0f;
    }

    if(!leftPressed && velocityX < 0.0f)
    {
      velocityX += Time.deltaTime * decelleration;
    }
    
    if(!rightPressed && velocityX < 0.0f)
    {
      velocityX -= Time.deltaTime * decelleration;
    }

    if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
    {
      velocityX = 0.0f;
    }

    if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
    {
      velocityZ = currentMaxVelocity;
    }
    else if(forwardPressed && velocityZ > currentMaxVelocity )
    {
      velocityZ -= Time.deltaTime * decelleration;

      if (velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity + 0.05f))
      {
        velocityZ = currentMaxVelocity;
      }
    }
    else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
    {
      velocityZ = currentMaxVelocity;
    }
  
    
    anim.SetFloat("Velocity z", velocityZ);
    anim.SetFloat("Velocity x", velocityX);
  }
}
