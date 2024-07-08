using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // The player object to follow
    public float distance = 5.0f; // Distance from the player
    public float height = 2.0f; // Height above the player
    public float sensitivity = 5.0f; // Mouse sensitivity
    public float rotationSmoothTime = 0.1f; // Smooth time for rotation

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Right mouse button for camera control
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, -35, 60); // Limit vertical rotation
        }

        Vector3 targetRotation = new Vector3(rotationY, rotationX);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;
        transform.position = player.position - transform.forward * distance + Vector3.up * height;
    }
}
