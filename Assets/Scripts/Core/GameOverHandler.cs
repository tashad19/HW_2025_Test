using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float fallThreshold = -5f;
    [SerializeField] string gameOverSceneName = "GameOverScene";

    bool isGameOver;

    void Update()
    {
        if (isGameOver)
            return;

        if (player == null)
            return;

        if (player.position.y < fallThreshold)
        {
            isGameOver = true;
            SceneManager.LoadSceneAsync(gameOverSceneName);
        }
    }
}
