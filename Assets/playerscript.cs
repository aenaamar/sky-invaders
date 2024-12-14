using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust movement speed
    public float accelSensitivity = 1f; // Sensitivity for accelerometer input (if needed)
    public float touchMoveSpeed = 5f; // Speed at which the spaceship moves towards touch position
    private Vector2 targetPosition; // The position the spaceship is moving towards
    private void Start()
    {
        targetPosition = transform.position; // Initialize the target position
    }

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)  // If there's any touch on the screen
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Single tap or drag for movement
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                // Set the target position to the touch position (scaled to world space)
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f; // Keep it in 2D plane
                targetPosition = touchPosition;
            }

            // Move towards the target position smoothly
            Vector3 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        // Handle keyboard input for movement (WASD or Arrow Keys)
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))  // Upward movement
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  // Downward movement
        {
            vertical = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  // Leftward movement
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))  // Rightward movement
        {
            horizontal = 1f;
        }

        // Move the spaceship based on keyboard input
        Vector2 moveDirectionKeyboard = new Vector2(horizontal, vertical).normalized;
        transform.position += (Vector3)moveDirectionKeyboard * moveSpeed * Time.deltaTime;
    }
}
