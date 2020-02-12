using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modul_Save : MonoBehaviour
{
    public GameObject ULT;

    public List<GameObject> BreadBoardArround;
    public List<GameObject> ArduinoArroun;

    public List<CreateAduinoSonic> UltCreateBtns;

    public Mousepoint PlayerMousePoint;

    public GameObject target;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartCoroutine(LoadFlow());
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            List<List<int>> AllsaveData = new List<List<int>>(); //전체를 담을 리스트

            List<int> save = new List<int>();//모듈 하나의 데이터
            save.Add(1);
            save.Add(1);
            save.Add(0);
            save.Add(4);
            save.Add(1);
            save.Add(26);
            save.Add(2);
            save.Add(27);
            save.Add(3);
            save.Add(5);

            AllsaveData.Add(save);//전체 데이터에 장입

            ES3.Save< List<List<int>> >("test2", AllsaveData); //저장
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            //파일 불러오기
            List<List<int>> save = new List<List<int>>();
            save = ES3.Load<List<List<int>>>("test2");

            for (int i = 0; i < save.Count; i++)
            {
                Debug.Log(save[i]);
            }
            
        }


    }

    private void Create(int ModulNum, int ModulKind)
    {
        switch (ModulNum)
        {
            case 1:
                target = UltCreateBtns[ModulKind-1].ClickEventReturn();
                break;
        }
        //생성하고 
    }

    private void LastPinClick(int i)
    {
        //디폴트 핀 클릭
        PlayerMousePoint.pointting = ArduinoArroun[i].transform.position;
        PlayerMousePoint.Rotation = ArduinoArroun[i].transform.rotation;
        ArduinoArroun[i].GetComponent<MouseOverArround>().OnMouseDown();
    }

    private void ModulPinClick(int i)
    {
        //모듈핀 클릭
        MouseOverArround modulArround = target.GetComponent<PinNumberList>().Arround[i].GetComponent<MouseOverArround>();
        modulArround.ReStart();
        modulArround.OnMouseDown();
    }

    IEnumerator LoadFlow()
    {
        //파일 불러오기
        List<List<int>> save = new List<List<int>>();
        save = ES3.Load<List<List<int>>>("test2");


        for (int i = 0; i < save.Count; i++)
        {
            Debug.Log(save[i].Count);
            Create(save[i][0], save[i][1]);

            for (int a = 0; a < save[i].Count-2; a++)
            {
                if (a % 2 == 1)//홀수면
                {
                    LastPinClick(save[i][a+2]);
                }
                else if (a % 2 == 0)//짝수면
                {
                    ModulPinClick(save[i][a+2]);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        

        //ModulPinClick(0);
        //LastPinClick(4);
        //yield return new WaitForSeconds(1.1f);

        //ModulPinClick(1);
        //LastPinClick(26);
        //yield return new WaitForSeconds(1.1f);

        //ModulPinClick(2);
        //LastPinClick(27);
        //yield return new WaitForSeconds(1.1f);

        //ModulPinClick(3);
        //LastPinClick(5);
        //yield return new WaitForSeconds(1.1f);
    }
}
