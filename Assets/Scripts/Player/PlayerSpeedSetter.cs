using UnityEngine;
using StarterAssets;

public class ApplyConfigToPlayer : MonoBehaviour
{
    ThirdPersonController controller;
    ConfigLoader config;

    void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        config = FindFirstObjectByType<ConfigLoader>();
        StartCoroutine(WaitAndApply());
    }

    System.Collections.IEnumerator WaitAndApply()
    {
        while (config == null || config.IsLoaded == false)
            yield return null;

        controller.MoveSpeed = config.Config.player_data.speed;
    }
}
