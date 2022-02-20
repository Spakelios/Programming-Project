using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelWalk : MonoBehaviour
{

    // Setup a variable to point to the Animator Controller for the character
    public Animator animator;

    // Setup 2 float for vertical/horizontal input
    float verticalInput;
    float horizontalInput;
    public bool runBool = false;
    public bool WaveBool = false;

    void Start()
    {
        //get the Animator Controller Component from the character component hierarchy
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input from vertical/horizontal axis
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Now set the animator float values (vAxisInput/hAxisInput)
        animator.SetFloat("vAxisInput", verticalInput);
        animator.SetFloat("hAxisInput", horizontalInput);

        // Detect Z Key press
        if (Input.GetKey("left shift"))
        {
            // Set runBool to true if pressed
            animator.SetBool("runBool", true);
            //Debug.Log ("Run");

        }
        else
        {
            // Set runBool to false if not pressed
            animator.SetBool("runBool", false);
            //Debug.Log ("No Run");
        }

        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("crouchBool", true);
        }
        else
        {
            animator.SetBool("crouchBool", false);
        }



        if (runBool == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                animator.SetBool("jumpBool", true);


            }
            else
            {

                animator.SetBool("jumpBool", false);

            }
        }
    }
}
