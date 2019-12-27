using System;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region 조도, 습도, 온도, 거리 값을 받아와 찾아 넣어주는 애들
    static public TextMesh temptext = GameObject.Find("TempValue").GetComponent<TextMesh>();
    static public TextMesh humitext = GameObject.Find("HumiValue").GetComponent<TextMesh>();
    static public TextMesh distancetext = GameObject.Find("DistanceValue").GetComponent<TextMesh>();
    static public TextMesh Luxtext = GameObject.Find("LuxValue").GetComponent<TextMesh>();
    #endregion

    #region 아두이노 센서들, 포트 번호 지정, 아두이노 실행할 때(?) 쓰는 것들
    public enum SensorType { Servo, Led, DC, Sound, Bread, Ult, Lux, HumiTemp, l298n, normal };

    private static SerialPort ArduinoPort = new SerialPort("COM5", 9600);
    static public ConnectArduino connectArduino = GameObject.Find("CodePaste").GetComponent<ConnectArduino>();

    static public RunButton runbtn = GameObject.Find("RunButton").GetComponent<RunButton>();
    static public PauseButton pausebtn = GameObject.Find("PauseButton").GetComponent<PauseButton>();
    static public SyncRunButton syncrunbutton = GameObject.Find("SyncRun").GetComponent<SyncRunButton>();
    static public SyncCodeButton syncCodebutton = GameObject.Find("SyncCode").GetComponent<SyncCodeButton>();
    #endregion

    #region 카메라등의 위치 변화에 사용되는 변수
    static public Vector3 canvasposition;

    static public Vector3 FirstMainCameraPosition;
    static public Quaternion FirstMainCameraRotation;
    #endregion

    #region 사용하는 문자열 저장하는 배열들
    static public List<string> ArduinoPortList = new List<string>();
    static public List<string> header = new List<string>();
    static public List<string> valuelist = new List<string>();
    static public List<string> setup = new List<string>();
    static public List<string> loop = new List<string>();
    #endregion

    #region 거리, 온도, 조도, 습도 선언 및 초기화
    static public float? distance = 0f;
    static public float? temp = 0f;
    static public float? humi = 0f;
    static public float? lux = 0f;
    #endregion

    #region 아누이노 실행할 때 사용하는 변수들 선언 및 초기화
    private static string codeM = null;

    static public bool PcOn = false;
    static public bool RunBlock = false;
    private static string PortNo = "";
    private static int BaudNo = 0;
    static public bool AgainSyncRun = false;
    #endregion

    #region 초기화
    private void Awake()
    {
        instance = this;

        ArduinoPort.ReadTimeout = 1000;
        ArduinoPort.WriteTimeout = 1000;
    }
    #endregion

    #region TextMesh에 넣는 문자열들 
    static public void SetHumitext(string _text)
    {
        humitext.text = _text;
    }

    static public void SetTemptext(string _text)
    {
        temptext.text = _text;
    }

    static public void Setdistancetext(string _text)
    {
        distancetext.text = _text;
    }

    static public void setLuxtext(string _text)
    {
        Luxtext.text = _text;
    }
    #endregion

    #region 문자열을 받아와서 없으면 저장해주고 있으면 찾아주는 함수들
    static public void AddloopList(string s)
    {
        bool check = false;

        for (int i = 0; i < loop.Count; i++)
        {
            if (loop[i] == s) check = true;
        }

        if (check == false)
        {
            loop.Add(s);
        }
    }

    static public void AddHeader(string s)
    {
        bool check = false;
        for (int i = 0; i < header.Count; i++)
        {
            if (header[i] == s) check = true;
        }

        if (check == false)
        {
            header.Add(s);
        }
    }

    static public void AddValueLis(string s)
    {
        bool check = false;
        for (int i = 0; i < valuelist.Count; i++)
        {
            if (valuelist[i] == s) check = true;
        }

        if (check == false)
        {
            valuelist.Add(s);
        }
    }

    static public void Addsetup(string s)
    {
        bool check = false;
        for (int i = 0; i < setup.Count; i++)
        {
            if (setup[i] == s) check = true;
        }

        if (check == false)
        {
            setup.Add(s);
        }
    }
    #endregion

    #region 아두이노 사용할 때 쓰는 함수들 == 미안 여긴 잘 모르겠어
    static public void RunbtnWork()
    {
        runbtn.Work();
    }

    #region 아두이노 코드 출력
    static public void MergeCode()
    {
        for (int i = 0; i < header.Count; i++)
        {
            codeM += header[i] + "\n";
        }

        for (int i = 0; i < valuelist.Count; i++)
        {
            codeM += valuelist[i] + "\n";
        }

        codeM += "void setup(){\n";

        if (setup.Count != 0)
        {
            for (int j = 0; j < setup.Count; j++)
            {
                codeM += setup[j] + "\n";
            }
        }
        else
            codeM += "\n";

        codeM += "}\n";

        codeM += "void loop(){" + "\n";

        if (loop.Count != 0)
        {
            for (int z = 0; z < loop.Count; z++)
            {
                codeM += loop[z] + "\n";
            }
        }
        else
            codeM += "\n";

        codeM += "}\n";

        

        GUIUtility.systemCopyBuffer = codeM;
        
        valuelist.Clear();
        setup.Clear();
        loop.Clear();
        header.Clear();
        codeM = null;
    }

    static public void syncBTMergeCode()
    {
        Addsetup("Serial.begin(9600);");
        AddHeader("#include <SoftwareSerial.h>");
        AddHeader("SoftwareSerial btSerial(2,3);");
        Addsetup("btSerial.begin(9600);");
        for (int i = 0; i < header.Count; i++)
        {
            codeM += header[i] + "\n";
        }

        for (int i = 0; i < valuelist.Count; i++)
        {
            codeM += valuelist[i] + "\n";
        }

        codeM += "void setup(){\n";

        for (int j = 0; j < setup.Count; j++)
        {
            codeM += setup[j] + "\n";
        }

        codeM += "}\n";

        codeM += "void loop(){" + "\n";

        codeM += "String sync=btSerial.readString();\n";

        for (int z = 0; z < loop.Count; z++)
        {
            codeM += loop[z] + "\n";
        }

        codeM += "}\n";

        GUIUtility.systemCopyBuffer = codeM;

        for (int i = 0; i < valuelist.Count; i++)
        {
            valuelist.RemoveAt(i);
        }

        for (int i = 0; i < setup.Count; i++)
        {
            setup.RemoveAt(i);
        }

        for (int i = 0; i < loop.Count; i++)
        {
            loop.RemoveAt(i);
        }

        for (int i = 0; i < header.Count; i++)
        {
            header.RemoveAt(i);
        }

        codeM = null;
    }

    static public void syncMergeCode()
    {
        //  AddValueLis("String sync;");
        Addsetup("Serial.begin(9600);");

        for (int i = 0; i < header.Count; i++)
        {
            codeM += header[i] + "\n";
        }

        for (int i = 0; i < valuelist.Count; i++)
        {
            codeM += valuelist[i] + "\n";
        }

        codeM += "void setup(){\n";

        for (int j = 0; j < setup.Count; j++)
        {
            codeM += setup[j] + "\n";
        }

        codeM += "}\n";

        codeM += "void loop(){" + "\n";

        codeM += "String sync=Serial.readString();\n";

        for (int z = 0; z < loop.Count; z++)
        {
            codeM += loop[z] + "\n";
        }

        codeM += "}\n";

        GUIUtility.systemCopyBuffer = codeM;

        for (int i = 0; i < valuelist.Count; i++)
        {
            valuelist.RemoveAt(i);
        }

        for (int i = 0; i < setup.Count; i++)
        {
            setup.RemoveAt(i);
        }

        for (int i = 0; i < loop.Count; i++)
        {
            loop.RemoveAt(i);
        }

        for (int i = 0; i < header.Count; i++)
        {
            header.RemoveAt(i);
        }

        codeM = null;
    }
    #endregion 아두이노 코드 출력


    static public void ReadArduinoValue()
    {
        string s = ArduinoPort.ReadLine();
        if (s != null) Setdistancetext(s);
        else if (s == null) Debug.Log("없다");
    }

    static public void ReadLuxArduinoValue()
    {
        string s = ArduinoPort.ReadLine();
        if (s != null) setLuxtext(s);
        else if (s == null) Debug.Log("없다");
    }

    static public void GetPort()
    {
        for (int i = 0; i < ArduinoPortList.Count; i++)
        {
            ArduinoPortList.RemoveAt(i);
        }

        foreach (string comport in SerialPort.GetPortNames())
        {
            ArduinoPortList.Add(comport);
        }

        if (ArduinoPortList[0] != null)
        {
            ArduinoPort = new SerialPort(ArduinoPortList[0], 9600);
        }
    }

    static public void closeArduino()
    {
        if (ArduinoPort.IsOpen == true)
        {
            ArduinoPort.Close();
        }
    }

    static public void openArduino()
    {
        try
        {
            ArduinoPort.Open();
        }
        catch (Exception)
        {
            syncrunbutton.blockgroupException();
        }
    }

    static public void DigitalWrite(string num)
    {
        ArduinoPort.Write(num);

        // GameManager.closeArduino();
    }

    static public void SyncPause()
    {
        AgainSyncRun = false;
        syncrunbutton.blockgrouppause();
    }

    static public void SyncRun()
    {
        if (AgainSyncRun == true)
        { syncrunbutton.blockgrouprun(); }
    }
    #endregion
}