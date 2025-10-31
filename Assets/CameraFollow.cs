using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;        // The player GameObject
    public float smoothSpeed = 0.125f; // Speed of the smoothing (lower is slower)
    public Vector3 offset;           // Offset from the player (x, y, z) to position the camera

    // Start is called before the first frame update
    void Start()
    {
        
        offset = new Vector3(0, 5, -10); // Example offset (5 units above, 10 units behind)
    }

    // Update is called once per frame
    void Update()
    {
        // The target position we want the camera to move towards
        Vector3 desiredPosition = player.transform.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // Optional: make the camera look at the player
        transform.LookAt(player.transform);
    }
}
