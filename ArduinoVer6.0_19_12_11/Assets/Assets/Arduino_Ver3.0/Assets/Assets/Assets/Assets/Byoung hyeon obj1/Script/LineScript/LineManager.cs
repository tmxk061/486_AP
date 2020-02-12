using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public int[] saveData = new int[2];
    private bool saveSettingCheck = false;
    public StartLine start;
    public End end;

    public float plusElectric = 0;
    public float minusElectric = 0;

    public bool ConnectBattery = false;
    public int ConnectSuccese = 0;
    public int Connect1 = 0;
    public int Connect2 = 0;

    public delegate void RunDelegate();
    public RunDelegate run;
    public delegate void PauseDelegate();
    public PauseDelegate pause;
    public delegate void RunServo(float s);
    public RunServo servorun;
    public delegate float LuxRead();
    public LuxRead luxRead;
    public delegate float UltRead();
    public UltRead ultRead;
    public delegate float WaterRead();
    public WaterRead waterRead;
    public delegate List<float> HumiTempRead();
    public HumiTempRead humitempRead;


    public GameManager.SensorType type = GameManager.SensorType.normal;

    public bool L298N_OUTCONNECT = false;

    //========================================
    [HideInInspector]
    public bool VccConnect;//plus
    [HideInInspector]
    public bool GNDConnect;//minus
    [HideInInspector]
    public bool DigitalConnect;//값 반환
    //========================================
    public GameObject child;

    public float Electro = 0.0f;

    public GameObject parent;
    
    public PlusGroup plusGroup;
    public int Power = 0;


    public void SaveDataSetting()
    {
        if (saveSettingCheck == true)
            return;
        
        Edu_Number num1 =null, num2=null;

        if (start.pm != null)
            num1 = start.pm.gameObject.transform.GetChild(0).GetComponent<Edu_Number>();
        else
            num1 = start.socket.gameObject.transform.GetChild(0).GetComponent<Edu_Number>();


        if (end.pm != null)
            num2 = end.pm.gameObject.transform.GetChild(0).GetComponent<Edu_Number>();
        else
            num2 = end.socket.gameObject.transform.GetChild(0).GetComponent<Edu_Number>();



        if (num1.modulNum == -1 || num1.modulNum == -2)
        {
            saveData[0] = num2.Number;
            saveData[1] = num1.Number;

            num2.parent.GetComponent<SaveData>().addPinList(GetComponent<LineManager>());
        }
        else
        {
            saveData[0] = num1.Number;
            saveData[1] = num2.Number;

            num1.parent.GetComponent<SaveData>().addPinList(GetComponent<LineManager>());
        }
    }

    private void Update()
    {
        if (start.pm != null || start.socket != null)
        {
            if (end.pm != null || end.socket != null)
            {
                SaveDataSetting();
                saveSettingCheck = true;
            }
        }
    }

    private void Start()
    {
        VccConnect = false;
        GNDConnect = false;
        DigitalConnect = false;
        start = GetComponentInChildren<StartLine>();
        end = GetComponentInChildren<End>();

    }

    public void RunCollect(float s)
    {

        if (run != null)
            run();

        if (servorun != null)
            servorun(s);



    }
    public void PauseCollect()
    {
        if (pause != null)
            pause();
    }


    public void SetParents(GameObject gameObject)
    {

        transform.SetParent(gameObject.transform);
    }

    private void FixedUpdate()
    {

        if (Connect1 == 1 && Connect2 == 1)
        {
            ConnectSuccese = 1;
            //transform.SetParent(parent.transform);
        }
        else if ((Connect1 == 0 || Connect2 == 0) && ConnectBattery == true)
        {
            Electro = 0;
            ConnectSuccese = 0;
        }
        else if ((Connect1 == 0 || Connect2 == 0) && ConnectBattery == false)
        {
            Electro = 0;
            ConnectSuccese = 0;
        }
    }

    private void OnDisable()
    {
        Connect1 = 0;
        Connect2 = 0;
        ConnectSuccese = 0;
        ConnectBattery = false;
        DigitalConnect = false;
        GNDConnect = false;
        VccConnect = false;

    }

    public void DestroyObject()
    {
        // gameObject.transform.DetachChildren();
        Destroy(this.gameObject);
    }
}
