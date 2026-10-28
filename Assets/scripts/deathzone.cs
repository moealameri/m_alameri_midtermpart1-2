using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform respawnPoint; // Where the player will teleport to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Safety check in case you forgot to drag the respawn point in
            if (respawnPoint == null)
            {
                Debug.LogError("ERROR: Respawn Point is not assigned on the DeathZone object in the Inspector!");
                return;
            }

            // If using a Character Controller component, disable it briefly to allow instant repositioning
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                other.transform.position = respawnPoint.position;
                controller.enabled = true;
            }
            else
            {
                // Basic transform movement
                other.transform.position = respawnPoint.position;
            }

            // Reset velocity if your player uses a Rigidbody so they don't keep falling
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            Debug.Log("Player respawned successfully!");
        }
    }
}