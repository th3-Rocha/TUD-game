using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform target; // Player's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the player
    public float chaseSpeed = 5f; // Speed at which the camera chases the player

    private void Update()
    {
        if (target == null)
            return;

        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position using Slerp
        transform.position = Vector3.Slerp(transform.position, desiredPosition, chaseSpeed * Time.deltaTime);
    }
}