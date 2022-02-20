using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        bool isWalking = anim.GetBool("isWalking");
        bool fowardPressed = Input.GetKey("w");

        if (!isWalking && fowardPressed)
        {
            anim.SetBool("isWalking", true);
        }

        else if (isWalking && fowardPressed)
        {
            anim.SetBool("isWalking", false);
        }
        
    }
}