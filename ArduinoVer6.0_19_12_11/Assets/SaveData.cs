using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
   
    public int ModulNum;
    public int ModulKind;

    public List<LineManager> pinList = new List<LineManager>();

    public void addPinList(LineManager data)
    {
        pinList.Add(data);
    }

    public List<int> CreateData()
    {
        Debug.Log("1");
        List<int> data = new List<int>();

        data.Add(ModulNum);
        data.Add(ModulKind);

        data.Add((int)gameObject.transform.position.x);
        data.Add((int)gameObject.transform.position.y);
        data.Add((int)gameObject.transform.position.z);

        for (int i = 0; i < pinList.Count; i++)
        {
            if (pinList[i] != null)
            {
                Debug.Log("2");
                data.Add(pinList[i].saveData[0]);
                data.Add(pinList[i].saveData[1]);
            }
            
        }
        Debug.Log("3");
        return data;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            List<int> data = CreateData();

            for (int i = 0; i < data.Count; i++)
            {
                Debug.Log(data[i]);
            }

        }
    }
}
