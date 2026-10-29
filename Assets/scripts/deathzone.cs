using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                // Instantly deal enough damage to trigger death and respawn at the last touched checkpoint
                health.TakeDamage(health.maxHealth);
            }
        }
    }
}