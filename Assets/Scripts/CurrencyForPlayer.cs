using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour { public static CurrencyManager Instance { get; private set; } public int currency = 0; [SerializeField] private Text currencyText;

    void Awake()
    {
        Debug.Log("CurrencyManager initialized.");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateCurrencyDisplay();
        if (scene.name == "level1" || scene.name == "levelPicker")
        {
            Text newText = GameObject.Find("CurrencyText")?.GetComponent<Text>();
            if (newText != null)
            {
                SetCurrencyText(newText);
            }
            else
            {
                Debug.LogWarning("CurrencyText not found in scene: " + scene.name);
            }
        }
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateCurrencyDisplay();
    }

    public bool SpendCurrency(int amount)
    {
        if (currency >= amount)
        {
            currency -= amount;
            UpdateCurrencyDisplay();
            return true;
        }
        return false;
    }

    public void SetCurrencyText(Text newText)
    {
        currencyText = newText;
        UpdateCurrencyDisplay();
    }

    void UpdateCurrencyDisplay()
    {
        if (currencyText != null)
        {
            currencyText.text = "Currency: " + currency;
        }
        else
        {
            Debug.LogWarning("Currency text not assigned in CurrencyManager!");
        }
    }

}