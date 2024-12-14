using UnityEngine;

public class asteroid : MonoBehaviour
{
    public int points = 10;  // Points for destroying this asteroid
    public GameObject explosionPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Instantiate explosion effect
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // Destroy the asteroid
            Destroy(gameObject);

            // Add score for destroying the asteroid
            mainscenemgr.AddScore(points);

            // Immediately update the UI to reflect the new score
            var manager = FindObjectOfType<mainscenemgr>();
            if (manager != null)
            {
                int health = PlayerPrefs.GetInt("health", 5);  // Retrieve current health
                int score = PlayerPrefs.GetInt("score", 0);   // Retrieve updated score
                manager.UpdateUI(health, score);              // Update the UI
            }
        }
    }
}