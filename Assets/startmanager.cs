using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class startmanager : MonoBehaviour
{
    // Function to load the main game scene
    public void StartGame()
    {
        SceneManager.LoadScene("skyivaders_1"); // Replace with your main game scene name
    }

    // Function to quit the game
    public void ExitGame()
    {
        // Exits the game when built; has no effect in the editor
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        // If testing in the editor, log a message
        Debug.Log("Game exited");
    }
}
