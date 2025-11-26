using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] string mainSceneName = "MainScene";

    public void Retry()
    {
        Time.timeScale = 1f;
        ScoreStorage.CurrentScore = 0;
        SceneManager.LoadSceneAsync(mainSceneName);
    }

}
