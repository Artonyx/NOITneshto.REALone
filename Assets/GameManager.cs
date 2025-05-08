using UnityEngine; using UnityEngine.UI;

public class GameManager : MonoBehaviour { 
    public static GameManager Instance { get; private set; } 
    public GameObject deathScreen;
    public bool IsGameOver { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        IsGameOver = false;
        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0f; // Pause the game
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Death screen is not assigned in GameManager!");
        }
    }

}