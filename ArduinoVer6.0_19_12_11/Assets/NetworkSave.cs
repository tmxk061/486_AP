using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSave : MonoBehaviour
{

    public void OnNetworkSave(string key, string name, string date)
    {
        List<List<int>> targetData = ES3.Load<List<List<int>>>(key);
        string NetworkSaveData = SeriallizeModulData(name, date, targetData);
        Debug.Log(NetworkSaveData);
    }

    private string SeriallizeModulData(string name,string date, List<List<int>> realData)
    {
        string result = name + "#" + date + "#" + "@";

        for (int i = 0; i < realData.Count; i++)
        {
            for (int a = 0; a < realData[i].Count; a++)
            {
                result += realData[i][a];
                result += "#";
            }
            result += "@";
        }

        return result;
    }

}
