using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Auto_Edu_Mgr : MonoBehaviour
{
    private bool isStart = false;
    private bool clickCheck = false;

    private string[,] Edu_order;
    private int Now_Order;

    private int[] MissonTarget1 = new int[2];
    private int[] MissonTarget2 = new int[2];

    private int[] AnserTarget1 = new int[2];
    private int[] AnserTarget2 = new int[2];

    private List<int> AnswerList;

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
        Checking();
    }

    private void Checking()//판정
    {
        if (!isStart)
            return;

        Debug.Log("미션 -" + MissonTarget1[0] + "," + MissonTarget1[1]);
        Debug.Log(AnserTarget1[0] + "," + AnserTarget1[1]);

        if (MissonTarget1.SequenceEqual(AnserTarget1) && MissonTarget2.SequenceEqual(AnserTarget2))
        {
            Debug.Log("정방향 정답");
        }

        if (MissonTarget1.SequenceEqual(AnserTarget2) && MissonTarget2.SequenceEqual(AnserTarget1))
        {
            Debug.Log("역방향 정답");
        }
    }

    public void ClickEvent(int[] data)
    {
        if (clickCheck) //두번째 클릭
        {
            //if (data.SequenceEqual(AnserTarget1)) //첫번째클릭과 같은거 클릭하면 초기화
            //{
            //    clickCheck = false;
            //    AnserTarget1 = new int[] { 0, 0 };
            //    AnserTarget2 = new int[] { 0, 0 };
            //    return;
            //}
            clickCheck = false;
            AnserTarget2 = data;
            //답을 집어넣는다.
        }
        else //첫번째 클릭
        {
            clickCheck = true;
            AnserTarget1 = data;
            AnserTarget2 = new int[] {0,0};
        }
    }
}