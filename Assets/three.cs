using UnityEngine;

public class three : MonoBehaviour
{
    public GameObject asteroidPrefab1;  // First asteroid prefab
    public GameObject asteroidPrefab2;  // Second asteroid prefab
    public GameObject powerUpPrefab;    // Power-up prefab
    public float spawnInterval = 2f;    // Time between spawns
    public float asteroidSpeed = 3f;    // Speed of falling objects
    public float spawnWidth = 3f;       // Width of spawn area (horizontal)
    public float destroyAfterTime = 5f; // Time after which object will be destroyed
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0;
        }
    }

    void SpawnObject()
    {
        // Randomize spawn position
        float randomX = Random.Range(-spawnWidth / 2, spawnWidth / 2);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        // Randomly choose which object to spawn (two types of asteroids or a power-up)
        GameObject objectToSpawn = Random.value < 0.7f
            ? (Random.value < 0.5f ? asteroidPrefab1 : asteroidPrefab2) // 50% chance to spawn asteroid1, 50% chance to spawn asteroid2
            : powerUpPrefab;  // 30% chance to spawn a power-up

        // Create the object
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // If it is an asteroid, apply downward velocity
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -asteroidSpeed);
        }

        // Destroy the object after a certain time
        Destroy(spawnedObject, destroyAfterTime);
    }
}
