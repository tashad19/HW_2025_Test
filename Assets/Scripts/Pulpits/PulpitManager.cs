using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;

    ConfigLoader config;
    List<GameObject> pulpits = new List<GameObject>();
    Vector3 currentPos = Vector3.zero;

    private float animationDuration = 1.0f; 
    private float pulseSpeed = 10f; 

    void Start()
    {
        config = FindFirstObjectByType<ConfigLoader>();
        StartCoroutine(WaitForConfig());
    }

    System.Collections.IEnumerator WaitForConfig()
    {
        while (config == null || config.IsLoaded == false)
            yield return null;

        SpawnInitial();
        StartCoroutine(SpawnLoop());
    }

    void SpawnInitial()
    {
        GameObject p = Instantiate(pulpitPrefab, currentPos, Quaternion.identity);
        pulpits.Add(p);
        StartCoroutine(DestroyAfterTime(p));
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(config.Config.pulpit_data.pulpit_spawn_time);
            SpawnNext();
        }
    }

    void SpawnNext()
    {
        Vector3[] dirs = new Vector3[]
        {
            new Vector3(9.01f,0,0),
            new Vector3(-9.01f,0,0),
            new Vector3(0,0,9.01f),
            new Vector3(0,0,-9.01f)
        };

        Vector3 nextPos = currentPos + dirs[Random.Range(0, dirs.Length)];

        while (nextPos == currentPos)
        {
            nextPos = currentPos + dirs[Random.Range(0, dirs.Length)];
        }

        currentPos = nextPos;

        GameObject p = Instantiate(pulpitPrefab, currentPos, Quaternion.identity);
        pulpits.Add(p);

        if (pulpits.Count > 2)
        {
            if(pulpits[0] != null) Destroy(pulpits[0]);
            pulpits.RemoveAt(0);
        }

        StartCoroutine(DestroyAfterTime(p));
    }

    IEnumerator DestroyAfterTime(GameObject p)
    {
        float totalLifeTime = Random.Range(config.Config.pulpit_data.min_pulpit_destroy_time, config.Config.pulpit_data.max_pulpit_destroy_time);
        
        float animTime = animationDuration;
        float waitTime = totalLifeTime - animTime;

        if (waitTime < 0)
        {
            waitTime = 0;
            animTime = totalLifeTime;
        }

        if (waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
        }

        if (p != null)
        {
            Renderer[] allRenderers = p.GetComponentsInChildren<Renderer>();
            
            Dictionary<Material, Color> originalColors = new Dictionary<Material, Color>();

            foreach (Renderer r in allRenderers)
            {
                foreach (Material m in r.materials)
                {
                    if (!originalColors.ContainsKey(m))
                    {
                        originalColors.Add(m, m.color);
                    }
                }
            }

            float timer = 0f;

            while (timer < animTime)
            {
                if (p == null) yield break;

                timer += Time.deltaTime;
                float alpha = Mathf.Lerp(0.2f, 1.0f, (Mathf.Sin(timer * pulseSpeed) + 1.0f) / 2.0f);

                foreach (var entry in originalColors)
                {
                    Material mat = entry.Key;
                    Color baseColor = entry.Value;
                    
                    Color newColor = baseColor;
                    newColor.a = alpha;
                    mat.color = newColor;
                }

                yield return null;
            }
        }

        if (pulpits.Contains(p))
        {
            pulpits.Remove(p);
        }
        
        if (p != null) Destroy(p);
    }
}