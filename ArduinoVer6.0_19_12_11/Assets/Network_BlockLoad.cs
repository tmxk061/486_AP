using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Network_BlockLoad : MonoBehaviour
{
    public List<string[]> DataList = new List<string[]>();


    [SerializeField]
    private GameObject CatalogBtn;

    [SerializeField]
    private Transform parent; //버튼 생성될부모

    List<GameObject> BtnList = new List<GameObject>();


    public void OnrefreshBtnClick() //네트워크 데이터 불러오기 트리거(목록만)
    {
        StartCoroutine(LoadCatalog());
    }

    IEnumerator LoadCatalog()
    {
        DataList.Clear();
        string DataListSellial = "";
        //네트워크에서 전체 데이터 목록을 가져와 DataListSellial에 넣는다.
        try
        {
            byte[] data = null;

            string catalog = ("LoadBlock!");
            byte[] d = Encoding.Default.GetBytes(catalog);
            NetworkSave.instance.SendData(NetworkSave.instance.socket1, d);

            //데이터 recv
            NetworkSave.instance.ReceiveData(NetworkSave.instance.socket1, ref data);
            string str = Encoding.Default.GetString(data);
            DataListSellial = str;
            Debug.Log(str);
        }
        catch (Exception e)
        {
            Debug.Log("Socket send or receive error ! : " + e.ToString());
        }

        DataList = NetworkLoadData(DataListSellial);

        //카탈로그를 구현시킨다.
        MakeCatalog();
        yield return null;
    }




    //문자열을 리스트로 나눠 정리
    public List<string[]> NetworkLoadData(string data)
    {
        Debug.Log(data);
        List<string[]> result = new List<string[]>();

        string[] Split = data.Split(new char[] { '!' });
        for(int i = 0; i < Split.Length; i++)
        {
            if (Split[i] == "")
                Split[i].Remove(i);
        }
        for (int i = 1; i < Split.Length; i++)
        {
            string[] Split2 = Split[i].Split(new char[] { '#' });
            Debug.Log(Split2[0]);
            Debug.Log(Split2[1]);
            Debug.Log(Split2[2]);
            string[] real = new string[] { Split2[0], Split2[1], Split2[2] };
            result.Add(real);
        }

        return result;
    }



    private string FirstSplit(string DataListSellial)
    {
        //DataList를 역직렬화해서 전역변수 DataList에 담는다.
        string[] FirstSplit = DataListSellial.Split(new char[] { '!' });

        string kind = FirstSplit[0];

        string datas = "";

        for (int i = 1; i < FirstSplit.Length; i++)
        {
            datas += FirstSplit[i];
            datas += "!";
        }

        return datas;
    }




    private void MakeCatalog() //실제 카탈로그를 구현한다.
    {
        ContentClear();

        //데이터 카탈로그를 구현한다.
        for (int i = 0; i < DataList.Count; i++)
        {
            GameObject newBtn = Instantiate(CatalogBtn);
            newBtn.SetActive(true);
            newBtn.transform.parent = parent;
            newBtn.transform.position = parent.position;
            newBtn.transform.localScale = CatalogBtn.transform.localScale;

            newBtn.GetComponentInChildren<Text>().text = DataList[i][0];

            newBtn.GetComponent<Net_BlockCatalogBtn>().NAME = DataList[i][0];
            newBtn.GetComponent<Net_BlockCatalogBtn>().DATE = DataList[i][1];
            newBtn.GetComponent<Net_BlockCatalogBtn>().realData = DataList[i][2];

            BtnList.Add(newBtn);
        }
    }




    private void ContentClear()//리스트 내부 전체 삭제
    {
        for (int i = 0; i < BtnList.Count; i++)
        {
            GameObject.Destroy(BtnList[i]);
        }
        BtnList.Clear();
    }
}
