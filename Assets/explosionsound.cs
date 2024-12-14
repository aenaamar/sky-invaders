using UnityEngine;

public class explosionsound : MonoBehaviour
{
    public AudioClip explosionClip; // Assign the explosion sound in the Inspector
    public float soundVolume = 1.0f; // Set the volume of the sound

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = explosionClip;
        audioSource.volume = soundVolume;
        audioSource.playOnAwake = false; // Ensure the sound doesn't play on start
    }

    // Method to play the explosion sound
    public void PlayExplosionSound()
    {
        if (explosionClip != null)
        {
            audioSource.Play(); // Play the explosion sound
        }
        else
        {
            Debug.LogWarning("Explosion clip is not assigned!");
        }
    }
}
