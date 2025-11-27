using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PulpitManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject pulpitPrefab;
    [SerializeField] private float animationDuration = 1.0f;
    [SerializeField] private float pulseSpeed = 10f;

    private ConfigLoader config;
    private List<GameObject> pulpits = new List<GameObject>();
    private Vector3 currentPos = Vector3.zero;

    private class PulpitVisuals
    {
        public TextMeshPro TimerText;
        public Dictionary<Material, Color> BaseColors;
    }

    private void Start()
    {
        config = FindFirstObjectByType<ConfigLoader>();
        StartCoroutine(WaitForConfig());
    }

    private IEnumerator WaitForConfig()
    {
        while (config == null || !config.IsLoaded)
            yield return null;

        SpawnInitial();
        StartCoroutine(SpawnLoop());
    }

    private void SpawnInitial()
    {
        SpawnPulpitAt(currentPos);
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(config.Config.pulpit_data.pulpit_spawn_time);
            SpawnNext();
        }
    }

    private void SpawnNext()
    {
        Vector3 nextPos = CalculateNextPosition();
        SpawnPulpitAt(nextPos);

        if (pulpits.Count > 2)
        {
            GameObject oldPulpit = pulpits[0];
            pulpits.RemoveAt(0);
            if (oldPulpit != null) Destroy(oldPulpit);
        }
    }

    private void SpawnPulpitAt(Vector3 position)
    {
        currentPos = position;
        GameObject p = Instantiate(pulpitPrefab, currentPos, Quaternion.identity);
        pulpits.Add(p);
        StartCoroutine(PulpitLifecycleRoutine(p));
    }

    private Vector3 CalculateNextPosition()
    {
        Vector3[] directions = {
            new Vector3(9.01f, 0, 0),
            new Vector3(-9.01f, 0, 0),
            new Vector3(0, 0, 9.01f),
            new Vector3(0, 0, -9.01f)
        };

        Vector3 nextPos;
        do
        {
            nextPos = currentPos + directions[Random.Range(0, directions.Length)];
        } 
        while (nextPos == currentPos);

        return nextPos;
    }

    private IEnumerator PulpitLifecycleRoutine(GameObject p)
    {
        float lifetime = Random.Range(config.Config.pulpit_data.min_pulpit_destroy_time, 
                                      config.Config.pulpit_data.max_pulpit_destroy_time);

        PulpitVisuals visuals = CacheVisuals(p);
        float timeRemaining = lifetime;

        while (timeRemaining > 0)
        {
            if (p == null) yield break;

            timeRemaining -= Time.deltaTime;

            UpdateTimer(visuals.TimerText, timeRemaining);

            if (timeRemaining <= animationDuration)
            {
                AnimatePulse(visuals.BaseColors, timeRemaining);
            }

            yield return null;
        }

        CleanupPulpit(p);
    }

    private PulpitVisuals CacheVisuals(GameObject p)
    {
        PulpitVisuals visuals = new PulpitVisuals
        {
            TimerText = p.GetComponentInChildren<TextMeshPro>(),
            BaseColors = new Dictionary<Material, Color>()
        };

        Renderer[] renderers = p.GetComponentsInChildren<Renderer>();
        
        foreach (Renderer r in renderers)
        {
            if (visuals.TimerText != null && r.gameObject == visuals.TimerText.gameObject) 
                continue;

            foreach (Material m in r.materials)
            {
                if (!visuals.BaseColors.ContainsKey(m))
                {
                    visuals.BaseColors.Add(m, m.color);
                }
            }
        }
        return visuals;
    }

    private void UpdateTimer(TextMeshPro textComponent, float timeRemaining)
    {
        if (textComponent != null)
        {
            textComponent.text = Mathf.Max(0, timeRemaining).ToString("F1");
        }
    }

    private void AnimatePulse(Dictionary<Material, Color> baseColors, float timeRemaining)
    {
        float animTimer = animationDuration - timeRemaining;
        float alpha = Mathf.Lerp(0.2f, 1.0f, (Mathf.Sin(animTimer * pulseSpeed) + 1.0f) / 2.0f);

        foreach (var entry in baseColors)
        {
            Color newColor = entry.Value;
            newColor.a = alpha;
            entry.Key.color = newColor;
        }
    }

    private void CleanupPulpit(GameObject p)
    {
        if (pulpits.Contains(p))
        {
            pulpits.Remove(p);
        }
        if (p != null) Destroy(p);
    }
}