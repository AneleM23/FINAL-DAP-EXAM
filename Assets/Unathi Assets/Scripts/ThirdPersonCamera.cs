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
        // Get input values
        float mouseX = Input.GetMouseButton(1) ? Input.GetAxis("Mouse X") : 0f;
        float mouseY = Input.GetMouseButton(1) ? Input.GetAxis("Mouse Y") : 0f;

        float rightStickX = Input.GetAxis("RightStickX"); // Make sure this exists in Input Manager
        float rightStickY = Input.GetAxis("RightStickY");

        // Combine inputs (mouse only if RMB is held, or right stick)
        float inputX = mouseX + rightStickX;
        float inputY = mouseY + rightStickY;

        // Only rotate if there's meaningful input
        if (Input.GetMouseButton(1) || Mathf.Abs(rightStickX) > 0.1f || Mathf.Abs(rightStickY) > 0.1f)
        {
            rotationX += inputX * sensitivity;
            rotationY -= inputY * sensitivity;
            rotationY = Mathf.Clamp(rotationY, -35, 60);
        }

        Vector3 targetRotation = new Vector3(rotationY, rotationX);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;
        transform.position = player.position - transform.forward * distance + Vector3.up * height;
    }

}
