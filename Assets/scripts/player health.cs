using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI healthText; // Drag your HealthText UI here

    private Vector3 currentRespawnPosition;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        // Set initial respawn position to where the player starts the game
        currentRespawnPosition = transform.position;
    }

    // Called by checkpoints when the player touches them
    public void SetRespawnPoint(Vector3 newPosition)
    {
        currentRespawnPosition = newPosition;
        Debug.Log("Checkpoint Updated!");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();
        Debug.Log("Player hit! Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        Debug.Log("Player Died! Respawning at last checkpoint...");

        // Temporarily disable CharacterController so we can teleport safely
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = currentRespawnPosition;
            controller.enabled = true;
        }
        else
        {
            transform.position = currentRespawnPosition;
        }

        // Reset Rigidbody velocity if your player has one
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Reset health back to full
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
}