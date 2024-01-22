using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class JSONInput : MonoBehaviour
{
    public static Data data;

    string url = "https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json";

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Webrequest error : " + webRequest.error);
            }
            else
            {
                data = JsonUtility.FromJson<Data>(webRequest.downloadHandler.text);
            }
        }
    }
}

[System.Serializable]
public class Data
{
    public playerData player_data;
    public pulpitData pulpit_data;
}

[System.Serializable]
public class playerData
{
    public float speed;
}

[System.Serializable]
public class pulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}