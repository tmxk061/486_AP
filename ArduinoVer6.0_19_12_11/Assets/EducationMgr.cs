using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EducationMgr : MonoBehaviour
{
    #region 아두이노, 빵판

    [Header("아두이노,빵판---")]
    [SerializeField]
    private List<Transform> ArduinoPoint; //아두이노 위치목록

    [SerializeField]
    private List<Transform> BreadBoardPoint; //빵판 위치목록

    #endregion 아두이노, 빵판

    #region 모듈

    [Header("모듈---")]
    [SerializeField]
    private Transform Modul_Parent; // 모듈을 담을 부모

    [SerializeField]
    private List<Transform> Modul_Pos; // 모듈이 생성될 위치 목록

    [SerializeField]
    private List<GameObject> Moduls; //모듈 프리팹 목록

    
    public List<GameObject> Used_Modul_Array; //현재 사용될 모듈 목록

    #endregion 모듈

    #region 라인

    [Header("라인----")]
    [SerializeField]
    private Transform LineParents; // 모든라인을 담을 부모 오브젝트

    [SerializeField]
    private GameObject Line2D; //라인 오브젝트

    #endregion 라인

    #region 데이터
    public int Edu_ID = 1;
    [SerializeField]
    private int Max_Edu_ID = 1;

    private int[] Modul_data;
    private string[,] Modul_order;

    #endregion 데이터

    #region 오더

    [Header("오더----")]
    public int NowOrder = 0;

    [SerializeField]
    private Text NowText;

    [SerializeField]
    private List<GameObject> LineList;

    #endregion 오더

    #region View
    [Header("View----")]
    [SerializeField]
    private GameObject MenuView;
    [SerializeField]
    private GameObject MainView;
    #endregion

    private void Start()
    {
        setting();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Edu_ID == Max_Edu_ID)
                return;

            Edu_ID +=1;
            setting();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Edu_ID == 1)
                return;

            Edu_ID -= 1;
            setting();
        }
    }

    public void setting() //세팅
    {
        Reset();

        Modul_data = Edu_table_Mgr.GetModulTable(Edu_ID);
        Modul_order = Edu_table_Mgr.GetModulOrder(Edu_ID);

        for (int i = 1; i < Modul_data.Length; i++)
        {
            if (Modul_data[i] == 0)
                continue;

            //사용될 모듈을 생성하고 배치한다.
            GameObject newModul = Instantiate(Moduls[Modul_data[i]]);
            newModul.transform.parent = Modul_Parent;
            newModul.transform.position = Modul_Pos[i-1].position;

            //사용될 모듈 목록을 받아와서 Modul_Array에 집어넣는다.
            //Used_Modul_Array.Add(Moduls[data[i]]);
            Used_Modul_Array[i-1] = newModul;
        }
    }

    private void Reset()
    {
        NowOrder = 0;

        for (int i = 0; i < Used_Modul_Array.Count; i++) //사용 모듈 삭제
        {
            if (Used_Modul_Array[i] != null)
                Destroy(Used_Modul_Array[i].gameObject);

            Used_Modul_Array[i] = null;
        }

        for (int i = 0; i < LineList.Count; i++) //라인 초기화
        {
            Destroy(LineList[i].gameObject);
        }
        LineList.Clear();

        Modul_data = null;
        Modul_order = null;
        NowText.text = "";
    }

    private void UpdateOrder()
    {
        try
        {
            Transform target1;
            Transform target2;

            int num1 = int.Parse(Modul_order[NowOrder, 2]); //타겟 핀넘버
            int num2 = int.Parse(Modul_order[NowOrder, 4]);

            target1 = Order_TargetSetting(num1, 1); //타겟 설정
            target2 = Order_TargetSetting(num2, 2);

            CreateLine(target1, target2); //라인 생성

            NowText.text = Modul_order[NowOrder, 5]; //텍스트 업데이트
        }
        catch
        {
            throw new Exception();

        }
        
    }

    private void CreateLine(Transform target1, Transform target2)
    {
        GameObject newLine = Instantiate(Line2D);
        newLine.transform.parent = LineParents;
        LineMgr2D lineMgr = newLine.GetComponent<LineMgr2D>();

        lineMgr.Point1Set(target1.position);
        lineMgr.Point2Set(target2.position);
        lineMgr.UpdateLine();

        LineList.Add(newLine); //되돌리기를 위한 현재라인 장입
    }

    private Transform Order_TargetSetting(int num, int targetNum)
    {
        if (targetNum == 1)
            targetNum = 1;
        else
            targetNum = 3;

        switch (Modul_order[NowOrder, targetNum]) //타겟 1
        {
            case "-1":
                return ArduinoPoint[num];

            case "-2":
                return BreadBoardPoint[num];

            default:
                return Used_Modul_Array[
                                            int.Parse(Modul_order[NowOrder, targetNum])-1
                                          ].GetComponent<EduModul>().PinList[num-1].transform;
        }
    }

    public void Btn_OnBackClick()
    {
        if (NowOrder == 0)
            return;

        Destroy(LineList[LineList.Count - 1].gameObject);
        LineList.RemoveAt(LineList.Count - 1);
        NowOrder--;
    }

    public void Btn_OnNextClick()
    {
        try
        {
            UpdateOrder();
            NowOrder++;
        }
        catch
        {
            NowOrder = 0;
            setting();
        }
    }

    public void Btn_OnMenuClick()
    {
        MenuView.SetActive(true);
        MainView.SetActive(false);
    }

    internal string[,] GetModulOrder()
    {
        return Modul_order;
    }
}