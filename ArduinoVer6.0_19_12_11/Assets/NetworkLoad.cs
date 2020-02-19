using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text;

public class NetWorkLoad : MonoBehaviour
{
    List<string[]> DataList = new List<string[]>();


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
        string DataListSellial = "";
        //네트워크에서 전체 데이터 목록을 가져와 DataListSellial에 넣는다.
        try
        {
            byte[] data = null;

            string catalog = ("LoadInfo!");
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
        //DataList를 역직렬화해서 전역변수 DataList에 담는다.

        //카탈로그를 구현시킨다.
        MakeCatalog();
        yield return null;
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

            newBtn.GetComponent<Net_CatalogBtn>().KEY = DataList[i][0];
            newBtn.GetComponent<Net_CatalogBtn>().NAME = DataList[i][1];
            newBtn.GetComponent<Net_CatalogBtn>().DATE = DataList[i][2];

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
