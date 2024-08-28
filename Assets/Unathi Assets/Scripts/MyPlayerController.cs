using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MyPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 720f;
    public float jumpForce = 7f;
    public float gravity = 9.81f;

    private CharacterController characterController;
    [SerializeField] private Animator animator;
    private Vector3 moveDirection;
    private float verticalVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = characterController.isGrounded;
        animator.SetBool("isJumping", !isGrounded);

        Move();
        HandleJump(isGrounded);
        UpdateAnimator();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        if (move.magnitude >= 0.1f)
        {
            // Calculate the target angle
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            // Smoothly rotate towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Calculate the move direction based on the target angle
            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            moveDirection.y = 0; // Ensure no vertical movement is included in horizontal direction

            // Move the player
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void HandleJump(bool isGrounded)
    {
        if (isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 verticalMove = new Vector3(0, verticalVelocity, 0);
        characterController.Move(verticalMove * Time.deltaTime);
    }

    void UpdateAnimator()
    {
        // Update the isRunning parameter based on movement
        bool isRunning = moveDirection.magnitude > 0;
        animator.SetBool("isRunning", isRunning);
    }

}
