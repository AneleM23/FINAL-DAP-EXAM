using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class MyPlayerController : MonoBehaviour
{
    [SerializeField] TaxiUI taxiUI;

    public float moveSpeed = 5f;
    public float swimSpeed = 3f; // Speed while swimming
    public float turnSpeed = 720f;
    public float jumpForce = 7f;
    public float gravity = 9.81f;
    public float groundCheckDistance = 0.1f; // Distance for ground detection
    public LayerMask groundLayer; // Layer to detect as ground
    public LayerMask waterLayer; // Layer to detect as water

    private CharacterController characterController;
    [SerializeField] private Animator animator;
    private Vector3 moveDirection;
    private float verticalVelocity;
    private bool isGrounded;
    private bool isSwimming;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GroundCheck();
        WaterCheck(); // New water detection method
        if (isSwimming)
        {
            Swim();
        }
        else
        {
            Move();

            if (!taxiUI.taxiUI.activeInHierarchy)
            HandleJump();
        }
        UpdateAnimator();
    }

    void GroundCheck()
    {
        // Use a raycast to detect if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayer);

        // Debug line to visualize the raycast in the scene view
        Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);
    }

    void WaterCheck()
    {
        //// Check if the player is in water (off the terrain)
        //isSwimming = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, waterLayer);

        // If player is in water, adjust vertical velocity to simulate buoyancy
        if (isSwimming)
        {
            verticalVelocity = 0f; // Neutralize gravity in water for buoyancy effect
        }
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

    void Swim()
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
            characterController.Move(moveDirection * swimSpeed * Time.deltaTime); // Use swimSpeed while in water
        }

        // Swimming up and down
        if (Input.GetKey(KeyCode.Space)) // Space to swim upward
        {
            verticalVelocity = swimSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift)) // LeftShift to swim downward
        {
            verticalVelocity = -swimSpeed * Time.deltaTime;
        }
        else
        {
            verticalVelocity = 0f; // No vertical movement
        }

        characterController.Move(new Vector3(0, verticalVelocity, 0));
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

        // Update the isSwimming parameter based on water check
        animator.SetBool("isSwimming", isSwimming);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Tag your water object as "Water"
        {
            isSwimming = true; // Start swimming
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isSwimming = false; // Stop swimming
        }
    }
}
