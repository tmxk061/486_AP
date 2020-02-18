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
    private void Awake()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
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

    #region 유니티 오브젝트 작동 부분
    public override void RunDetail()
    {
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
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;
        
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

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.SyncRun(s));
            GetChild = true;
        }

        if (GetChild == false)
        { GameManager.closeArduino(); GameManager.SyncRun(); }
    }
    #endregion 유니티 오브젝트 작동 부분

    #region 아두이노 코드 출력
    public override void GetCode()
    {

        base.GetCode();
    }

    public override void AddCode()
    {
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

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(s));
            GetChild = true;
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

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncBTMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }
    #endregion 아두이노 코드 출력
}