using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Exit button clicked: Game is quitting...");
        Application.Quit();
    }
}