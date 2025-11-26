using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ConfigLoader : MonoBehaviour
{
    public DoofusConfig Config { get; private set; }
    public string apiUrl = "https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json";
    public bool IsLoaded { get; private set; }

    void Awake()
    {
        StartCoroutine(LoadConfigFromApi());
    }

    IEnumerator LoadConfigFromApi()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            Config = JsonUtility.FromJson<DoofusConfig>(json);
            IsLoaded = true;
        }
        else
        {
            Debug.LogError("Failed to load config from API");
        }
    }
}
