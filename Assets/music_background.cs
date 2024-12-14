using UnityEngine;

public class music_background : MonoBehaviour
{
    private static music_background instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Prevent duplicate music
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep music across scenes
        }
    }
}
