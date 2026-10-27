using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player hit! Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player Died! Triggering Game Over...");

        // Find the GameOverManager in the scene and trigger game over
        GameOverManager manager = FindObjectOfType<GameOverManager>();
        if (manager != null)
        {
            manager.TriggerGameOver();
        }
        else
        {
            Debug.LogWarning("No GameOverManager found in the scene!");
        }
    }
}