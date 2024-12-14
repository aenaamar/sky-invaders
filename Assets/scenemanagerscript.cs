using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenemanagerscript : MonoBehaviour
{
    public Text healthText;  // UI Text reference for health
    public Text scoreText;   // UI Text reference for score
    public int scoreThreshold = 100;  // Score required to move to the next level
    public string nextLevelSceneName = "leveltwo";  // Name of the next level scene

    private void Start()
    {
        // Retrieve health and score from PlayerPrefs
        int health = PlayerPrefs.GetInt("health", 10);  // Default to 10 if not set
        int score = PlayerPrefs.GetInt("score", 0);     // Default to 0 if not set

        // Update the UI
        UpdateUI(health, score);
    }

    private void Update()
    {
        // Retrieve health and score from PlayerPrefs
        int health = PlayerPrefs.GetInt("health", 10);
        int score = PlayerPrefs.GetInt("score", 0);

        // Check if health is zero
        if (health <= 0)
        {
            // Store the score in PlayerPrefs before transitioning to the game over scene
            PlayerPrefs.SetInt("score", score);

            // Load the Game Over scene
            SceneManager.LoadScene("gameoverscene");  // Replace with your Game Over scene name
        }
        else if (score >= scoreThreshold)
        {
            // If score reaches the threshold, load the next level
            SceneManager.LoadScene(nextLevelSceneName);  // Replace with your next level scene name
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
