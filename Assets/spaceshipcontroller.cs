using UnityEngine;
using UnityEngine.SceneManagement;

public class spaceshipcontroller : MonoBehaviour
{
    public float speed = 5f;       // Normal spaceship speed
    public float speedBoost = 2f;  // Speed increase when power-up is collected
    public float boostDuration = 5f; // Duration of the speed boost
    private float currentSpeed;
    private bool isBoosted = false;
    private float boostTimer = 0f;

    void Start()
    {
        currentSpeed = speed; // Set initial speed
    }

    void Update()
    {
        // Move the spaceship
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * currentSpeed * Time.deltaTime;
        transform.Translate(movement);

        // If the speed boost is active, start a timer
        if (isBoosted)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostDuration)
            {
                ResetSpeed();
            }
        }

        if (Input.GetKeyDown(KeyCode.N))  // Press 'N' to force transition
        {
            SceneManager.LoadScene("skyivaders_3");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp")) // Detect collision with power-up
        {
            Destroy(collision.gameObject); // Destroy the power-up on collision
            ActivateSpeedBoost();
        }
    }

    void ActivateSpeedBoost()
    {
        if (!isBoosted)
        {
            isBoosted = true;
            currentSpeed = speed * speedBoost; // Increase spaceship speed
            boostTimer = 0f;
        }
    }

    void ResetSpeed()
    {
        currentSpeed = speed;  // Reset to original speed
        isBoosted = false;
    }
}
