using UnityEngine;

public class asteroid_spawnnerscript : MonoBehaviour
{
    public GameObject asteroidPrefab; // Assign the asteroid prefab in the Inspector
    public float spawnInterval = 5f;  // Time between spawns
    public float asteroidSpeed = 3f;  // Speed of falling asteroids
    public float spawnWidth = 3f;     // Width of spawn area (horizontal)
    public float destroyAfterTime = 5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnAsteroid();
            timer = 0;
        }

        
    }

    void SpawnAsteroid()
    {
        // Randomize spawn position
        float randomX = Random.Range(-spawnWidth / 2, spawnWidth / 2);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        // Create the asteroid
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Add downward velocity
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -asteroidSpeed);
        }
        Destroy(asteroid, destroyAfterTime);


    }
}
