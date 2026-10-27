using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button mainMenuButton; // Drag your button here, or it will auto-find it!

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TriggerGameOver()
    {
        // 1. Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 2. Unlock and show the mouse cursor immediately
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 3. Disable player movement and camera look scripts so they stop moving/locking the mouse
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Disable standard movement/mouse scripts if they exist on the player
            MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
            foreach (var script in scripts)
            {
                if (script != this) script.enabled = false;
            }
        }

        if (Camera.main != null)
        {
            MonoBehaviour[] camScripts = Camera.main.GetComponents<MonoBehaviour>();
            foreach (var script in camScripts)
            {
                script.enabled = false;
            }
        }

        // 4. Pause the game time
        Time.timeScale = 0f;

        // 5. Automatically find the button if not assigned, and select it for mouse/keyboard focus
        if (mainMenuButton == null)
        {
            mainMenuButton = FindObjectOfType<Button>();
        }

        if (mainMenuButton != null && EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(mainMenuButton.gameObject);
        }
    }

    public void LoadMainMenu()
    {
        Debug.Log("Main Menu button was clicked!");
        Time.timeScale = 1f; // Unpause before loading scene
        SceneManager.LoadScene(0); // Loads Scene index 0 (Your Main Menu)
    }
}