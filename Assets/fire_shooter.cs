using UnityEngine;

public class FireShooter : MonoBehaviour
{
    public GameObject projectilePrefab;  // The projectile prefab
    public Transform shootPoint;         // The point from where the projectile is fired
    public float projectileSpeed = 10f;  // Speed of the projectile
    public AudioSource audioSource;      // Reference to the AudioSource component
    private float lastTapTime = 0f;      // To track time between taps
    public float doubleTapThreshold = 0.3f; // Threshold time for double tap (in seconds)

    private void Update()
    {
        // Handle touch input (movement and firing)
        if (Input.touchCount > 0)  // If there's any touch on the screen
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Detect double tap for firing
            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapThreshold)
                {
                    FireProjectile();  // Fire the projectile if it's a double tap
                }
                lastTapTime = Time.time; // Update the last tap time
            }
        }

        // Handle spacebar input for firing
        if (Input.GetKeyDown(KeyCode.Space)) // If spacebar is pressed
        {
            FireProjectile();  // Fire the projectile
        }
    }

    // Fire a projectile when the user taps the screen (double tap condition checked in the Update method)
    void FireProjectile()
    {
        // Instantiate the projectile at the shoot point (front of the spaceship)
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component to move the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity to move the projectile upwards (or forwards if it's angled)
        if (rb != null)
        {
            rb.velocity = new Vector2(0, projectileSpeed); // Adjust direction as needed
        }

        // Play the shooting sound
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Optionally, destroy the projectile after some time to avoid clutter
        Destroy(projectile, 5f); // Adjust the lifetime as needed
    }
}
