using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modul_Save : MonoBehaviour
{
    public static Modul_Save instance;
    public void Awake()
    {
        Modul_Save.instance = this;

        try
        {
            KEY = ES3.Load<int>("MODUL_KEY");
        }
        catch
        {
            Debug.Log("저장된 키 없음");
        }

        try
        {
            Modul_DB = ES3.Load<List<string[]>>("Modul_DB");
        }
        catch
        {
            Debug.Log("저장된 모듈 없음");
        }
    }


    public List<string[]> Modul_DB = new List<string[]>();
    private int KEY =0;
    public List<GameObject> BreadBoardArround;
    public List<GameObject> ArduinoArroun;
    public List<LineManager> LonlyLine = new List<LineManager>();

    public List<CreateAduinoSonic> UltCreateBtns;
    public List<CreateAduinoTemp> TempCreateBtns;
    public List<CreateAduinoIll> IllCreateBtns;

    public CreateAduinoScript water;
    public CreateAduinoScript servo;
    public CreateAduinoScript DcMotor;
    public CreateAduinoScript boozer;
    public CreateLED LED;

    public Mousepoint PlayerMousePoint;

    public GameObject target;

    public GameObject SaveUI;
    public GameObject LoadUI;


 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SaveUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadUI.SetActive(true);
        }
        

        if (Input.GetKeyDown(KeyCode.F4))
        {
            DeleteModul("MODUL_1");

        }
    }

    
    public void Save(string Name)
    {
        KEY++;
            
        List<List<int>> AllsaveData = new List<List<int>>(); //전체를 담을 리스트

        //모듈과 연결된 부분 저장
        SaveData[] AllModul = GameObject.FindObjectsOfType<SaveData>();
        for (int i = 0; i < AllModul.Length; i++)
        {
            List<int> save = new List<int>();//모듈 하나의 데이터
            save = AllModul[i].CreateData();
            AllsaveData.Add(save);//전체 데이터에 장입
        }

        //부모없는 선 저장
        for (int a = 0; a < LonlyLine.Count; a++)
        {
            if (LonlyLine[a] == null)
                continue;

            List<int> LonlySave = new List<int>();
            LonlySave.Add(0);
            LonlySave.Add(0);
            LonlySave.Add(LonlyLine[a].num1.Number);
            LonlySave.Add(LonlyLine[a].num2.Number);

            AllsaveData.Add(LonlySave);//전체 데이터에 장입
        }
        LonlyLine.Clear();
        ES3.Save<List<List<int>>>("MODUL_" + KEY.ToString(), AllsaveData); //저장



        //DB에 저장
        string[] DbData = new string[] { "MODUL_"+KEY.ToString(), Name, System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") };
        Modul_DB.Add(DbData);
        ES3.Save<List<string[]>>("Modul_DB", Modul_DB);
        ES3.Save<int>("MODUL_KEY", KEY); //현재 키저장
        Debug.Log("저장완료");
    }

    public void Load(string KEY)
    {
        Debug.Log(KEY);
        StartCoroutine(LoadFlow(KEY));
    }


    IEnumerator LoadFlow(string LoadKey)
    {
        //파일 불러오기
        List<List<int>> save = new List<List<int>>();
        save = ES3.Load<List<List<int>>>(LoadKey);

        for (int i = 0; i < save.Count; i++)
        {
            if (save[i][0] == 0) //부모가 없으면
            {
                LastPinClick(save[i][2]);
                yield return new WaitForSeconds(0.1f);
                LastPinClick(save[i][3]);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {

                Create(save[i][0], save[i][1], save[i][2], save[i][3], save[i][4]);

                yield return new WaitForSeconds(0.3f);

                for (int a = 0; a < save[i].Count - 5; a++)
                {
                    if (a % 2 == 1)//홀수면
                    {
                        LastPinClick(save[i][a + 5]);

                    }
                    else if (a % 2 == 0)//짝수면
                    {
                        ModulPinClick(save[i][a + 5]);
                    }

                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }



    private void Create(int ModulNum, int ModulKind, int x, int y, int z)
    {

        switch (ModulNum)
        {
            case 1:
                target = UltCreateBtns[ModulKind-1].ClickEventReturn();
                target.transform.position = new Vector3(x, y, z);
                break;
            case 2:
                target = TempCreateBtns[ModulKind - 1].ClickEventReturn();
                target.transform.position = new Vector3(x, y, z);
                break;
            case 3:
                target = IllCreateBtns[ModulKind - 1].ClickEventReturn();
                target.transform.position = new Vector3(x, y, z);
                break;
            case 4:
                target = water.ClickEventReturn();
                target.transform.position = new Vector3(x, y, z);
                break;
            case 5:
                target = servo.ClickEventReturn();
                target.transform.position = new Vector3(x, y, z);
                break;
            case 6:
                target = boozer.ClickEventReturn();
                target.transform.position = new Vector3(x, y, z);
                break;
        }
        //생성하고 
    }

    private void LastPinClick(int i)
    {

        if (i >= 500)
        {
            i = i - 1000;
            //디폴트 핀 클릭
            PlayerMousePoint.pointting = ArduinoArroun[i - 1].transform.position;
            PlayerMousePoint.Rotation = ArduinoArroun[i - 1].transform.rotation;
            ArduinoArroun[i - 1].GetComponent<MouseOverArround>().OnMouseDown();
        }
        else
        {
            Debug.Log(i-1);
            PlayerMousePoint.pointting = BreadBoardArround[i - 1].transform.position;
            PlayerMousePoint.Rotation = BreadBoardArround[i - 1].transform.rotation;
            BreadBoardArround[i - 1].GetComponent<MouseOverArround>().OnMouseDown();
        }
        
    }

    private void ModulPinClick(int i)
    {
        //모듈핀 클릭
        MouseOverArround modulArround = target.GetComponent<PinNumberList>().Arround[i-1].GetComponent<MouseOverArround>();
        modulArround.ReStart();
        modulArround.OnMouseDown();
    }



    public List<string[]> GetModul_DB()
    {
        return Modul_DB;
    }

    public void DeleteModul(string KEY)
    {
        for (int i = 0; i < Modul_DB.Count; i++)
        {
            if (Modul_DB[i][0].Equals(KEY))
            {
                Modul_DB.RemoveAt(i);
                break;
            }

        }

        ES3.DeleteKey(KEY);
        ES3.Save<List<string[]>>("Modul_DB", Modul_DB);
    }

}
