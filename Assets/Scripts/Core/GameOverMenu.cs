using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] string mainSceneName = "MainScene";

    public void Retry()
    {
        SceneManager.LoadSceneAsync(mainSceneName);
    }
}
