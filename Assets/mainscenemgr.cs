using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainscenemgr : MonoBehaviour
{
    public Text healthText;  // UI Text reference for health
    public Text scoreText;   // UI Text reference for score

    private void Start()
    {
        // Retrieve health and score from PlayerPrefs
        int health = PlayerPrefs.GetInt("health", 10);  // Default to 5 if not set
        int score = PlayerPrefs.GetInt("score", 0);    // Default to 0 if not set

        // Update the UI
        UpdateUI(health, score);
    }

    private void Update()
    {
        // Retrieve health from PlayerPrefs
        int health = PlayerPrefs.GetInt("health", 10);

        // Check if health is zero
        if (health <= 0)
        {
            // Store the score in PlayerPrefs before transitioning to the game over scene
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score"));

            // Load the Game Over scene
            SceneManager.LoadScene("gameoverscene");  // Replace with your Game Over scene name
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Decrease health
            int health = PlayerPrefs.GetInt("health", 10);
            health--;

            // Save updated health to PlayerPrefs
            PlayerPrefs.SetInt("health", health);

            // Update the UI
            UpdateUI(health, PlayerPrefs.GetInt("score"));

            // Check if health is zero
            if (health <= 0)
            {
                // Load the Game Over scene
                SceneManager.LoadScene("gameoverscene");  // Replace with your Game Over scene name
            }
        }
    }

    public static void AddScore(int points)
    {
        // Update score in PlayerPrefs
        int score = PlayerPrefs.GetInt("score", 0);
        score += points;
        PlayerPrefs.SetInt("score", score);
    }

    // **Changed to public to make it accessible**
    public void UpdateUI(int health, int score)
    {
        if (healthText != null)
        {
            healthText.text = "health: " + health.ToString();  // Update health UI
        }

        if (scoreText != null)
        {
            scoreText.text = "score: " + score.ToString();  // Update score UI
        }
    }
}
