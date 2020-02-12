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
        if (Input.GetKeyDown(KeyCode.F2))
        {
            StartCoroutine(LoadFlow());
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Save();
        }

        //if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    //파일 불러오기
        //    List<List<int>> save = new List<List<int>>();
        //    save = ES3.Load<List<List<int>>>("test2");

        //    for (int i = 0; i < save.Count; i++)
        //    {
        //        Debug.Log(save[i]);
        //    }

        //}


    }

    private void Save()
    {
        List<List<int>> AllsaveData = new List<List<int>>(); //전체를 담을 리스트

        SaveData[] AllModul = GameObject.FindObjectsOfType<SaveData>();
        Debug.Log(AllModul.Length);
       
        for (int i = 0; i < AllModul.Length; i++)
        {
            List<int> save = new List<int>();//모듈 하나의 데이터
            save = AllModul[i].CreateData();
            
            AllsaveData.Add(save);//전체 데이터에 장입
        }
        //Debug.Log(AllsaveData[0][0] + "," + AllsaveData[0][1] + "," + AllsaveData[0][2] + "," + AllsaveData[0][3] + "," + AllsaveData[0][4]);
        ES3.Save<List<List<int>>>("test2", AllsaveData); //저장
        Debug.Log("저장완료");
    }


    private void Create(int ModulNum, int ModulKind)
    {
        Debug.Log(ModulNum +","+ ModulKind);

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
        PlayerMousePoint.pointting = ArduinoArroun[i-1].transform.position;
        PlayerMousePoint.Rotation = ArduinoArroun[i-1].transform.rotation;
        ArduinoArroun[i].GetComponent<MouseOverArround>().OnMouseDown();
    }

    private void ModulPinClick(int i)
    {
        //모듈핀 클릭
        Debug.Log("1");
        MouseOverArround modulArround = target.GetComponent<PinNumberList>().Arround[i-1].GetComponent<MouseOverArround>();
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
