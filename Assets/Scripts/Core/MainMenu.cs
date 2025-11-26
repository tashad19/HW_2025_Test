using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string mainSceneName = "MainScene";

    public void PlayGame()
    {
        ScoreStorage.CurrentScore = 0;
        SceneManager.LoadSceneAsync(mainSceneName);
    }
}
