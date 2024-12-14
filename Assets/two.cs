using UnityEngine;

public class two : MonoBehaviour
{
    public GameObject asteroidPrefab;  // First prefab (asteroid)
    public GameObject powerUpPrefab;   // Second prefab (e.g., power-up)
    public float spawnInterval = 2f;   // Time between spawns
    public float asteroidSpeed = 3f;   // Speed of falling objects
    public float spawnWidth = 3f;      // Width of spawn area (horizontal)
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

        // Randomly choose which object to spawn (asteroid or power-up)
        GameObject objectToSpawn = Random.value < 0.8f ? asteroidPrefab : powerUpPrefab; // 80% chance to spawn asteroid

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
