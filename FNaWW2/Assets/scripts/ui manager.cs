using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Text scoreText;
    [SerializeField] private string label = "Meth Count"; // 👈 You can change this in the Inspector if you want

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UpdateScoreText(0);
    }

    public void UpdateScoreText(int score)
    {
        // Update the UI text with your chosen label
        scoreText.text = label + ": " + score;
    }
}
