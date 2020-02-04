using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Auto_Edu_Mgr : MonoBehaviour
{
    public bool isStart = false;

    [SerializeField]
    private GameObject EndPopup;
    private bool clickCheck = false;

    private string[,] Edu_order;
    private int Now_Order;

    private int[] MissonTarget1 = new int[2];
    private int[] MissonTarget2 = new int[2];

    private int[] AnserTarget1 = new int[2];
    private int[] AnserTarget2 = new int[2];
    private GameObject AnserObject1;
    private GameObject AnserObject2;

    private List<int> AnswerList;

    public GameObject AlertCanvas;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void StartAuto()
    {
        isStart = true;
        Edu_order = GetComponent<EducationMgr>().GetModulOrder();
        UpdateMission();
        
        ////임시로 답안 제출
        //AnserTarget1[0] = 1;
        //AnserTarget1[1] = 1;

        //AnserTarget2[0] = -1;
        //AnserTarget2[1] = 1;
    }

    private void UpdateMission() //현재 나우오더를 기반으로 미션 생성
    {
        Now_Order = GetComponent<EducationMgr>().NowOrder;

        if (Now_Order == 0)
        {
            GetComponent<EducationMgr>().Btn_OnNextClick();
            Now_Order = GetComponent<EducationMgr>().NowOrder; //나우오더 다시 받기
        }

        MissonTarget1[0] = int.Parse(Edu_order[Now_Order - 1, 1]);
        MissonTarget1[1] = int.Parse(Edu_order[Now_Order - 1, 2]);

        MissonTarget2[0] = int.Parse(Edu_order[Now_Order - 1, 3]);
        MissonTarget2[1] = int.Parse(Edu_order[Now_Order - 1, 4]);

    }

    private void Update()
    {
        //Checking();

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("미션:" + MissonTarget1[0] + "," + MissonTarget1[1]);
            Debug.Log(MissonTarget2[0] + "," + MissonTarget2[1]);

            Debug.Log("답:" + AnserTarget1[0] + "," + AnserTarget1[1]);
            Debug.Log(AnserTarget2[0] + "," + AnserTarget2[1]);
        }
    }

    public void Checking()//판정
    {
        if (!isStart)
            return;
        //Debug.Log("미션 -" + MissonTarget1[0] + "," + MissonTarget1[1]);
        //Debug.Log(AnserTarget1[0] + "," + AnserTarget1[1]);

        int num = CheckRealObject();
        if (num == 1)
        {
            if (MissonTarget1.SequenceEqual(AnserTarget1) && MissonTarget2.SequenceEqual(AnserTarget2))
            {
                Debug.Log("정방향 정답");
                AlertCanvas.SetActive(true);
                ConfirmSensor.instance.GoodAnser();
                GetComponent<EducationMgr>().Btn_OnNextClick();
                UpdateMission();
            }
            else
            {
                AlertCanvas.SetActive(true);
                ConfirmSensor.instance.BadAnser();
            }
        }
        else if (num == 2)
        {
            if (MissonTarget1.SequenceEqual(AnserTarget2) && MissonTarget2.SequenceEqual(AnserTarget1))
            {
                Debug.Log("역방향 정답");
                AlertCanvas.SetActive(true);
                ConfirmSensor.instance.GoodAnser();
                GetComponent<EducationMgr>().Btn_OnNextClick();
                UpdateMission();
            }
            else
            {
                AlertCanvas.SetActive(true);
                ConfirmSensor.instance.BadAnser();
            }
        }
        else
        {
            AlertCanvas.SetActive(true);
            ConfirmSensor.instance.BadAnser();
        }

    }

    private int CheckRealObject()
    {
        
        GameObject MissonObject1 = null;
        GameObject MissonObject2 = null;

        //if (AnserObject1 == null)
        //    return 3;
        //if (AnserObject2 == null)
        //    return 3;
        if (MissonTarget1[0] > 0)
        {
            //미션1은 일반 모듈
            MissonObject1 = GetComponent<EducationMgr>().Used_Modul_Array[MissonTarget1[0]-1].GetComponent<EduModul>().RealModel;
        }
        else
        {
            //미션1은 디폴트 모듈
            if (MissonTarget1[0] == -1) //아두이노
            {
                MissonObject1 = GetComponent<EducationMgr>().Used_Modul_Array[9].GetComponent<EduModul>().RealModel;
            }
            else if (MissonTarget1[0] == -2) //빵판
            {
                MissonObject1 = GetComponent<EducationMgr>().Used_Modul_Array[10].GetComponent<EduModul>().RealModel;
            }
        }
        if (MissonTarget2[0] > 0)
        {
            //미션2은 일반 모듈
            MissonObject2 = GetComponent<EducationMgr>().Used_Modul_Array[MissonTarget2[0]-1].GetComponent<EduModul>().RealModel;
        }
        else
        {
            //미션2은 디폴트 모듈
            if (MissonTarget2[0] == -1) //아두이노
            {
                MissonObject2 = GetComponent<EducationMgr>().Used_Modul_Array[9].GetComponent<EduModul>().RealModel;
            }
            else if (MissonTarget2[0] == -2) //빵판
            {
                MissonObject2 = GetComponent<EducationMgr>().Used_Modul_Array[10].GetComponent<EduModul>().RealModel;
            }
        }

        if (MissonObject1 == AnserObject1 && MissonObject2 == AnserObject2)
        {
           // Debug.Log("정방향");
            return 1;
        }
        if (MissonObject1 == AnserObject2 && MissonObject2 == AnserObject1)
        {
            //Debug.Log("역방향");
            return 2;
        }

        //Debug.Log("불일치");
        return 0;

    }

    public void ClickEvent(int[] data, GameObject parent)
    {
        if (clickCheck) //두번째 클릭
        {
            clickCheck = false;
            AnserTarget2 = data;
            AnserObject2 = parent;
            //답을 집어넣는다.

            if (AnserTarget2[0] < 0)
                return;

            SwapMyNumber(parent, AnserTarget2);

        }
        else //첫번째 클릭
        {
            AnserTarget2 = new int[] { 0, 0 };

            clickCheck = true;
            AnserTarget1 = data;
            AnserObject1 = parent;

            //AnserTarget1[0] = 

            if (AnserTarget1[0] < 0)
                return;

            SwapMyNumber(parent, AnserTarget1);
        }
    }

    private void SwapMyNumber(GameObject parent, int[] AnserTarget)
    {
        
        for (int i = 0; i < GetComponent<EducationMgr>().Used_Modul_Array.Count; i++) //디폴트모듈이 아닐경우 자기 위치번호 넣어주기
        {
            Debug.Log(i);
            if (GetComponent<EducationMgr>().Used_Modul_Array[i] == null)
                continue;

            GameObject target = GetComponent<EducationMgr>().Used_Modul_Array[i].GetComponent<EduModul>().RealModel;

            if (target == null)
                continue;

            if (parent == target)
            {
                AnserTarget[0] = i+1;
                break;
            }
        }
    }

    public void EndAuto()
    {
        EndPopup.SetActive(true);
    }
}