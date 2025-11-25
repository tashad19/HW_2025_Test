using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string mainSceneName = "MainScene";

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(mainSceneName);
    }
}
