using UnityEngine;

public class ConfigLoader : MonoBehaviour
{
    public DoofusConfig Config { get; private set; }

    void Awake()
    {
        TextAsset json = Resources.Load<TextAsset>("doofus_diary");
        Config = JsonUtility.FromJson<DoofusConfig>(json.text);
    }
}
