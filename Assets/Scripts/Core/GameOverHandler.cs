using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float fallThreshold = -5f;
    [SerializeField] string gameOverSceneName = "GameOverScene";

    bool isGameOver;
    float delayBeforeCheck = 1f;

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
            return;

        delayBeforeCheck -= Time.deltaTime;
        if (delayBeforeCheck > 0f)
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
