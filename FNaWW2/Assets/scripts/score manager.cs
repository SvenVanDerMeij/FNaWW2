using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int CurrentScore { get; private set; }

    void Awake()
    {
        // Simple Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        UIManager.Instance.UpdateScoreText(CurrentScore);
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UIManager.Instance.UpdateScoreText(CurrentScore);
    }
}
