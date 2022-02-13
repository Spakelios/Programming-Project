using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharatherMovement : MonoBehaviour
{
    public Animator anim;
    private int isWalkingHash;
    private int isRunningHash;

    private PlayerInput Input;

    private Vector2 currentMovement;
    private bool movementPressed;
    private bool runPressed;

    
    private void Awake()
    {
        Input = new PlayerInput();

        Input.CharacterControls.Movement.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
        Input.CharacterControls.run.performed += ctx => runPressed = ctx.ReadValueAsButton();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    private void Update()
    {
        handleMovement();
    }

    void handleMovement()
    {
        bool isRunning = anim.GetBool(isRunningHash);
        bool isWalking = anim.GetBool(isWalkingHash);
        
        if (movementPressed && isWalking)
        {
            anim.SetBool(isWalkingHash, true);
        }

        if (!movementPressed && isWalking)
        {
            anim.SetBool(isWalkingHash, false);
        }

        if (movementPressed && runPressed && !isRunning)
        {
            anim.SetBool(isRunningHash, true);
        }
        
        if (!movementPressed || !runPressed && !isRunning)
        {
            anim.SetBool(isRunningHash, false);
        }

    }

    private void OnEnable()
    {
        Input.CharacterControls.Enable();
    }
    
    private void OnDisable()
    {
        Input.CharacterControls.Disable();
    }
}
