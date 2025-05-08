using UnityEngine; using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour { public static CurrencyManager Instance { get; private set; } public int currency = 0; [SerializeField] private Text currencyText;

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
        UpdateCurrencyDisplay();
    }

    void Start()
    {
        UpdateCurrencyDisplay();
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