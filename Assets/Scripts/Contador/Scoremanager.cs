using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Opciones")]
    [SerializeField] private bool clampToZero = true;
    [SerializeField] private string playerPrefsKey = "player_score";

    public int Score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResetScore(save: false);
        PlayerPrefs.DeleteKey(playerPrefsKey);
    }

    public void Add(int amount)
    {
        Score += amount;
        Debug.Log($"[ScoreManager] Add {amount} → Score = {Score}");
        UpdateUI();
        Save();
    }

    public void Subtract(int amount)
    {
        Score -= amount;
        if (clampToZero && Score < 0) Score = 0;
        Debug.Log($"[ScoreManager] Subtract {amount} → Score = {Score}");
        UpdateUI();
        Save();
    }

    public void ResetScore(bool save = true)
    {
        Score = 0;
        UpdateUI();
        if (save) Save();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = $"Puntos: {Score}";
        else
            Debug.LogWarning("[ScoreManager] Falta referencia a scoreText.");
    }

    private void Save()
    {
        PlayerPrefs.SetInt(playerPrefsKey, Score);
        PlayerPrefs.Save();
    }
}
