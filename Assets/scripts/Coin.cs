using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Tell the score manager to add a coin
            ScoreManager.Instance.AddCoin();
            Destroy(gameObject); // Disappear when collected
        }
    }
}