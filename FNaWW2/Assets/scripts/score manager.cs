using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private GameObject MethTally;
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
        MethTally.GetComponent<Methcounter>().Click();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UIManager.Instance.UpdateScoreText(CurrentScore);
    }
}
