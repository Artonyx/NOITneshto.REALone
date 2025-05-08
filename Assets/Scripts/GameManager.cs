using UnityEngine; using UnityEngine.SceneManagement; using UnityEngine.UI;

public class GameManager : MonoBehaviour { public static GameManager Instance { get; private set; } public GameObject deathScreen; public GameObject shopScreen; public Button returnToMenuButton; public bool IsGameOver { get; private set; }

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
        if (shopScreen != null)
        {
            shopScreen.SetActive(false);
        }
    }

    void Start()
    {
        if (returnToMenuButton != null)
        {
            returnToMenuButton.onClick.AddListener(ReturnToMainMenu);
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0f;
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Death screen not assigned in GameManager!");
        }
    }

    public void ToggleShop()
    {
        if (shopScreen != null)
        {
            shopScreen.SetActive(!shopScreen.activeSelf);
            Time.timeScale = shopScreen.activeSelf ? 0f : 1f;
        }
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelPicker");
    }

}