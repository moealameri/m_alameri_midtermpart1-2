using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform respawnPoint; // Optional: empty object where the player spawns. If empty, uses checkpoint's position.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Determine spawn location (uses specific respawnPoint transform if assigned, otherwise uses the checkpoint itself)
                Vector3 spawnPos = (respawnPoint != null) ? respawnPoint.position : transform.position;

                playerHealth.SetRespawnPoint(spawnPos);

                // Optional: Change checkpoint color or disable collider so it only triggers once
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}