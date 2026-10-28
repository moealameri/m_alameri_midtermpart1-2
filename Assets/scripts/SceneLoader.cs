using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resumes game time in case it was paused
        SceneManager.LoadScene(0); // Loads index 0 (your Main Menu scene)
    }
}