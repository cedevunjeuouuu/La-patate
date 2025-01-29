using System;
using UnityEngine;
[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 9.81f;
    private float horizontalMove = 0f;
    private Vector3 moveDirection;
    private bool jump = false;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        moveDirection.x = horizontalMove;
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (jump)
            {
                moveDirection.y = jumpForce;
                jump = false;
            }
        }
        
        moveDirection.y -= gravity * Time.fixedDeltaTime;
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }
}

