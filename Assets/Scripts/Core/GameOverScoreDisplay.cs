using UnityEngine;
using TMPro;

public class GameOverScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        currentScoreText.text = "Score: " + ScoreStorage.CurrentScore.ToString();
        highScoreText.text = "High Score: " + ScoreStorage.HighScore.ToString();
    }
}
