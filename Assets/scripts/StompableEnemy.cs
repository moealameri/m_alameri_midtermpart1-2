using UnityEngine;

public class StompableEnemy : MonoBehaviour
{
    public int enemyDamage = 1;
    public float bounceForce = 8f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Much more forgiving stomp check: 
            // If the player's vertical position is higher than the enemy's center point
            float playerY = collision.transform.position.y;
            float enemyTopY = transform.position.y + (transform.localScale.y * 0.3f);

            if (playerY > enemyTopY)
            {
                // SUCCESSFUL STOMP
                Debug.Log("Stomped Enemy Successfully!");

                // Optional: Apply upward bounce if player has a rigidbody
                Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
                }

                Destroy(gameObject); // Destroy the enemy
            }
            else
            {
                // HIT FROM SIDE/BOTTOM: Enemy hurts the player
                PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(enemyDamage);
                }
            }
        }
    }
}