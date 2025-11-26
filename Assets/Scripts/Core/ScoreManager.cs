using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = FindFirstObjectByType<TextMeshProUGUI>();
        UpdateUI();
    }

    public void AddPoint()
    {
        Score++;
        ScoreStorage.CurrentScore = Score;

        if (Score > ScoreStorage.HighScore)
        {
            ScoreStorage.HighScore = Score;
        }
        
        UpdateUI();

    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = Score.ToString();
    }
}
