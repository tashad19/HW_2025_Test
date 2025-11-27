using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    public TextMeshProUGUI scoreText; 

    void Start()
    {
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