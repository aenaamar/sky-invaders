using UnityEngine;
using UnityEngine.UI;  // For displaying score on UI

public class GameManager : MonoBehaviour
{
    public static int score = 0;  // Make score static so it can be accessed globally

    public Text scoreText;  // Reference to the UI Text component for displaying score

    void Start()
    {
        // Set the score text to the score when the scene starts
        scoreText.text = "Score: " + score.ToString();  // Use the static score variable
    }

    // Method to update the score (call this from wherever you want to add points)
    public static void AddScore(int points)
    {
        score += points;
    }
}
