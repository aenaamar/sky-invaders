using UnityEngine;
using UnityEngine.UI;  // To access UI elements

public class pausebuttonmgr : MonoBehaviour
{
    public Button resumeButton;   // Reference to the Resume Button
    public Image resumeButtonImage; // Reference to the Image component of the Resume Button
    public Sprite pauseIcon;     // Sprite for the "Pause" icon
    public Sprite playIcon;      // Sprite for the "Play" icon
    private bool isPaused = false;  // Flag to track if the game is paused

    void Start()
    {
        // Ensure that the Resume button is hooked up
        resumeButton.onClick.AddListener(TogglePause);

        // Initially make sure the game is not paused
        Time.timeScale = 1f;  // Normal game speed

        // Set initial image for the button
        UpdateButtonImage();
    }

    // Function to toggle the game pause/resume
    void TogglePause()
    {
        // Toggle the pause state
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game by setting time scale to 0
            Time.timeScale = 0f;  // Stops the game
        }
        else
        {
            // Resume the game by setting time scale back to 1
            Time.timeScale = 1f;  // Normal game speed
        }

        // Update the button image based on the new state
        UpdateButtonImage();
    }

    // Function to update the Resume button image based on pause state
    void UpdateButtonImage()
    {
        if (resumeButtonImage != null)
        {
            resumeButtonImage.sprite = isPaused ? playIcon : pauseIcon;
        }
    }
}
