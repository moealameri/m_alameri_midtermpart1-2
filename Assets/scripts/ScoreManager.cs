using UnityEngine;
using TMPro; // If using TextMeshPro, or use UnityEngine.UI for standard text

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int coinCount = 0;
    public TextMeshProUGUI coinText; // Drag your UI Text element here

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddCoin()
    {
        coinCount++;
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }
}