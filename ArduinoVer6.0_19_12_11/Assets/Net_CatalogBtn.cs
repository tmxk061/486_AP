using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net_CatalogBtn : MonoBehaviour
{
    public string KEY;
    public string NAME;
    public string DATE;
    public string realData;

    public void OnNetworkLoad()
    {
        List<List<int>> Alldata = new List<List<int>>();

        string TargetData = realData;
        TargetData = TargetData.Substring(1, TargetData.Length - 1);
        TargetData = TargetData.Substring(0, TargetData.Length - 1);
        string[] target = TargetData.Split(new char[] { '@' });

        for (int i = 0; i < target.Length; i++)
        {
            List<int> data = new List<int>();

            string d = target[i].Substring(0, target[i].Length - 1);
            string[] smallParsing = d.Split(new char[] { '$' });
            Debug.Log(smallParsing.Length);

            for (int a = 0; a < smallParsing.Length; a++)
            {
                data.Add(int.Parse(smallParsing[a]));
            }

            Alldata.Add(data);
        }

        GameObject.Find("SaveMgr").GetComponent<Modul_Save>().Load_Net(Alldata);
        GameObject.Find("close").GetComponent<Menu_Data_Close>().OnBtnClick();
        
    }

}
