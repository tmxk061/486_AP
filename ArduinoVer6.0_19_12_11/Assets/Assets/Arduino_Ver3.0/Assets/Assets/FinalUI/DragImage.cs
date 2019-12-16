using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// DigitalWrite

public class DragImage : Block
{
    #region 변수
    private ControlArduino arduino;
    public int selectnum = 0;
    public Socket selectSocket;

    [SerializeField]
    public Canvas canvas;

    public bool selectRun = true;
    public bool UpConncet = false;
    public bool DownConnect = false;

    [SerializeField]
    public Camera secondCamera;
    
    #endregion 변수
    

    public void SyncDigitalWrite()
    {
        string sen = null;

        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");

        if (selectRun == true)
        {
            sen += "if(sync==" + '"' + selectnum + "True" + '"' + ")\n{";
            sen += "digitalWrite(" + selectnum + ",HIGH);";
        }
        else if (selectRun == false)
        {
            sen += "if(sync==" + '"' + selectnum + "False" + '"' + ")\n{";
            sen += "digitalWrite(" + selectnum + ",LOW);";
        }

        sen += "\n}\n";

        GameManager.AddloopList(sen);
    }

    protected override void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();

        base.Start();
    }

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSocket = arduino.PinList[_num];
    }

    public void highlowsel(bool s)
    {
        selectRun = s;
    }
    
    public void DigitalWrite()
    {
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");

        if (selectRun == true)
        { GameManager.loop.Add("digitalWrite(" + selectnum + ",HIGH);"); }
        else if (selectRun == false)
        { GameManager.loop.Add("digitalWrite(" + selectnum + ",LOW);"); }
    }

    public void Tone()
    {
        GameManager.AddValueLis("int speakerPin =" + selectnum + ";");

        GameManager.loop.Add("tone(speakerPin,261);" + '\n' + "delay(500);" + "noTone(speakerPin);");
    }


    public override IEnumerator Run(float s)
    {
        GetChild = false;

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        if (selectSocket != null)
        {
            if (selectRun == true)
            {
                switch (selectSocket.SocketType)
                {
                    case GameManager.SensorType.Bread:
                        selectSocket.SocketRun(0);

                        break;

                    case GameManager.SensorType.normal:
                        selectSocket.SocketRun(0);
                        break;
                    //  DC모터 LED  Servo 등등 작동만 하는 것
                    case GameManager.SensorType.DC:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.l298n:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Led:

                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Servo:
                        break;

                    case GameManager.SensorType.Sound:
                        selectSocket.SocketRun(0);
                        break;
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.HumiTemp:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Lux:
                        selectSocket.SocketRun(0);
                        break;

                        //  selectSocket.SocketRun(0);
                }
            }
            else if (selectRun == false)
            {
                selectSocket.SocketPause();
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.Run(0)); ;
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;
            }
        }

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        if (GetChild == false && s == 0)
        {
            GameManager.RunbtnWork();
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;

        Block block = null;

        //  GameManager.DigitalWrite(selectnum.ToString());
        GameManager.DigitalWrite(selectnum + selectRun.ToString());

        if (selectSocket != null)
        {
            if (selectRun == true)
            {
                switch (selectSocket.SocketType)
                {
                    case GameManager.SensorType.Bread:
                        selectSocket.SocketRun(0);

                        break;

                    case GameManager.SensorType.normal:
                        selectSocket.SocketRun(0);
                        break;
                    //  DC모터 LED  Servo 등등 작동만 하는 것
                    case GameManager.SensorType.DC:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.l298n:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Led:

                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Servo:
                        break;

                    case GameManager.SensorType.Sound:
                        selectSocket.SocketRun(0);
                        break;
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.HumiTemp:
                        selectSocket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Lux:
                        selectSocket.SocketRun(0);
                        break;

                        //  selectSocket.SocketRun(0);
                }
            }
            else if (selectRun == false)
            {
                selectSocket.SocketPause();
            }
        }

        yield return new WaitForSecondsRealtime(2.0f);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;
            }
        }

        if (GetChild == false)
        { GameManager.closeArduino(); GameManager.SyncRun(); }
    }


    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Bread:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.normal:
                    break;
                //  DC모터 LED  Servo 등등 작동만 하는 것
                case GameManager.SensorType.DC:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.l298n:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.Led:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.Servo:
                    break;

                case GameManager.SensorType.Sound:
                    Tone();
                    break;
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:
                    //추후 추가 예정
                    break;

                case GameManager.SensorType.HumiTemp:

                    break;

                case GameManager.SensorType.Lux:
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;
            }
        }

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Bread:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.normal:
                    break;
                //  DC모터 LED  Servo 등등 작동만 하는 것
                case GameManager.SensorType.DC:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.l298n:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Led:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Servo:
                    break;

                case GameManager.SensorType.Sound:
                    Tone();
                    break;
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:
                    //추후 추가 예정
                    break;

                case GameManager.SensorType.HumiTemp:

                    break;

                case GameManager.SensorType.Lux:
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;
            }
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }
         
    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Bread:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.normal:
                    break;
                //  DC모터 LED  Servo 등등 작동만 하는 것
                case GameManager.SensorType.DC:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.l298n:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Led:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Servo:
                    break;

                case GameManager.SensorType.Sound:
                    Tone();
                    break;
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:
                    //추후 추가 예정
                    break;

                case GameManager.SensorType.HumiTemp:

                    break;

                case GameManager.SensorType.Lux:
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;
            }
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncBTMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }
}