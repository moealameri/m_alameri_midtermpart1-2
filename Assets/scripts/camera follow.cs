using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Drag your Player here in the Inspector

    [Header("Camera Settings")]
    public float mouseSensitivity = 3f;
    public float distanceFromPlayer = 6f;
    public Vector2 pitchLimits = new Vector2(-10f, 60f); // Prevents camera from flipping upside down

    private float yaw = 0f;   // Rotation around Y axis (left/right)
    private float pitch = 20f; // Rotation around X axis (up/down)

    void Start()
    {
        // Lock the mouse cursor to the center of the screen during gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Get mouse movement input
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

        // Calculate rotation and position around the player
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 targetPosition = target.position + Vector3.up * 1.5f - (rotation * Vector3.forward * distanceFromPlayer);

        // Apply to camera
        transform.rotation = rotation;
        transform.position = targetPosition;

        // Press ESCAPE if you ever need to see your mouse cursor again
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        // Click back onto the game screen to re-lock the mouse
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}