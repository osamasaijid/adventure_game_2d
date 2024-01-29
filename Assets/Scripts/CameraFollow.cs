using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player

    void LateUpdate()
    {
        // Set the camera's position to the player's position with the offset
        transform.position = player.position + offset;
    }
}
