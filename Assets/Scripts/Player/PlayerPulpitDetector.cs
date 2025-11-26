using UnityEngine;

public class PlayerPulpitDetector : MonoBehaviour
{
    ScoreManager scoreManager;
    GameObject lastPulpit;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pulpit") && other.gameObject != lastPulpit)
        {
            lastPulpit = other.gameObject;
            scoreManager.AddPoint();
        }
    }
}
