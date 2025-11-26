using UnityEngine;

public class PlayerSpawnSetter : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform player;

    void Start()
    {
        if (spawnPoint != null && player != null)
        {
            player.position = spawnPoint.position;
        }
    }
}
