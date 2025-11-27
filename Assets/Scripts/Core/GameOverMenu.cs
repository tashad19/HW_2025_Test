using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] string mainSceneName = "MainScene";

    public void Retry()
    {
        // Time.timeScale = 1f;  // not really needed delay
        ScoreStorage.CurrentScore = 0;
        SceneManager.LoadSceneAsync(mainSceneName);
    }

}
