using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float acceleration = 1500f; // Force applied for acceleration
    public float turnSpeed = 200f; // Speed of turning
    public float maxSpeed = 50f; // Maximum speed the car can reach
    public float deceleration = 500f; // Deceleration force when no input is given

    private Rigidbody rb; // Reference to the car's Rigidbody

    void Start()
    {
        // Get the Rigidbody component attached to the car
        rb = GetComponent<Rigidbody>();

        // Adjust Rigidbody drag for natural deceleration
        rb.drag = 3f; // Adjust as needed for a smoother stop
        rb.angularDrag = 2f; // Adjust the angular drag if needed for turning behavior
    }

    void Update()
    {
        // Get input for movement (W/S or Up/Down Arrow keys for forward/backward)
        float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow for forward/backward
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow for turning

        // Move the car forward/backward based on input
        MoveCar(moveInput);

        // Turn the car based on input
        TurnCar(turnInput);

        // Apply deceleration if no input is given
        if (moveInput == 0)
        {
            Decelerate();
        }
    }

    void MoveCar(float input)
    {
        // Apply force to move the car forward or backward if input is detected
        if (input != 0 && rb.velocity.magnitude < maxSpeed) // Limit the speed of the car
        {
            rb.AddForce(transform.forward * input * acceleration * Time.deltaTime, ForceMode.Force);
        }
    }

    void TurnCar(float input)
    {
        // Apply torque to the car to make it turn
        if (input != 0)
        {
            rb.AddTorque(transform.up * input * turnSpeed * Time.deltaTime, ForceMode.Force);
        }
    }

    void Decelerate()
    {
        // Apply a deceleration force in the opposite direction of the car's velocity
        if (rb.velocity.magnitude > 0)
        {
            rb.AddForce(-rb.velocity.normalized * deceleration * Time.deltaTime, ForceMode.Force);
        }
    }
}
