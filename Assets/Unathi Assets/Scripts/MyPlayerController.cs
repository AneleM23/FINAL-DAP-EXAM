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
    public float groundCheckDistance = 0.1f; // Distance for ground detection
    public LayerMask groundLayer; // Layer to detect as ground

    private CharacterController characterController;
    [SerializeField] private Animator animator;
    private Vector3 moveDirection;
    private float verticalVelocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Debug.Log(isGrounded);

        GroundCheck();
        Move();
        HandleJump();
        UpdateAnimator();

        animator.SetBool("isJumping", !isGrounded);
    }

    void GroundCheck()
    {
        // Use a raycast to detect if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayer);

        // Debug line to visualize the raycast in the scene view
        Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void HandleJump()
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

        // Update the isJumping parameter based on ground check
        animator.SetBool("isJumping", !isGrounded);
    }

}
