using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;

    ConfigLoader config;
    List<GameObject> pulpits = new List<GameObject>();
    Vector3 currentPos = Vector3.zero;
    bool spawning;

    void Start()
    {
        config = FindFirstObjectByType<ConfigLoader>();
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
            new Vector3(9,0,0),
            new Vector3(-9,0,0),
            new Vector3(0,0,9),
            new Vector3(0,0,-9)
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
            Destroy(pulpits[0]);
            pulpits.RemoveAt(0);
        }

        StartCoroutine(DestroyAfterTime(p));
    }

    IEnumerator DestroyAfterTime(GameObject p)
    {
        float t = Random.Range(config.Config.pulpit_data.min_pulpit_destroy_time, config.Config.pulpit_data.max_pulpit_destroy_time);
        yield return new WaitForSeconds(t);
        if (pulpits.Contains(p))
        {
            pulpits.Remove(p);
        }
        Destroy(p);
    }
}
