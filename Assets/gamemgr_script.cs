using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // For UI elements

public class gamemgr_script : MonoBehaviour
{
    public Button retryButton;   // The retry button
    public Button quitButton;    // The quit button
    public Text scoreText;       // UI Text to display the score

    void Start()
    {
        // Retrieve the score from PlayerPrefs and display it
        int finalScore = PlayerPrefs.GetInt("score", 0);  // Default to 0 if no score is stored
        scoreText.text = "Score: " + finalScore.ToString();

        // Add listeners for the buttons
        retryButton.onClick.AddListener(RetryGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Function to restart the game (load the main game scene)
    void RetryGame()
    {
        // Reinitialize health and score
        PlayerPrefs.SetInt("score", 0);    // Reset score
        PlayerPrefs.SetInt("health", 10);   // Reset health

        // Load the first level or main game scene
        SceneManager.LoadScene("skyivaders_1");  // Replace with your main game scene name
    }

    // Function to quit the game
    void QuitGame()
    {
        // Load the start page or quit application
        SceneManager.LoadScene("startpage"); // Replace with your start page name
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Stop playmode in the editor
#endif
    }
}
