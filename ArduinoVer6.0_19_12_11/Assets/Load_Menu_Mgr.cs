using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Menu_Mgr : MonoBehaviour
{
    public List<string[]> Main_Data;

    [SerializeField]
    private GameObject Btn; //생성할 버튼

    [SerializeField]
    private Transform parent; //버튼 생성될부모

    List<GameObject> BtnList = new List<GameObject>();

    private void OnEnable()
    {
        ContentClear();
        Main_Data = Modul_Save.instance.GetModul_DB();

        for (int i = 0; i < Main_Data.Count; i++)
        {
            GameObject newbtn = Instantiate(Btn);
            newbtn.SetActive(true);
            newbtn.transform.parent = parent;
            newbtn.transform.position = parent.position;
            newbtn.transform.localScale = Btn.transform.localScale;

            //newbtn.GetComponent<StudyBtn>().ID = int.Parse(Main_Data[i][0]);
            newbtn.GetComponentInChildren<Text>().text = Main_Data[i][0] + " , " + Main_Data[i][1] + " , " + Main_Data[i][2];
            newbtn.GetComponent<LoadBtn>().KEY = Main_Data[i][0];
            newbtn.GetComponent<LoadBtn>().NAME = Main_Data[i][1];
            newbtn.GetComponent<LoadBtn>().DATE = Main_Data[i][2];

            BtnList.Add(newbtn);
        }
    }


    private void ContentClear()
    {
        for (int i = 0; i < BtnList.Count; i++)
        {
            GameObject.Destroy(BtnList[i]);
        }
        BtnList.Clear();
    }

    
}
