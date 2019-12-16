using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UltBlock : Block
{
    #region 변수

    //[SerializeField]
    //public Canvas canvas;
    //public bool UpConncet = false;
    //public bool DownConnect = false;
    //[SerializeField]
    //public Camera secondCamera;
    
    public int selectnum = 0;
    public int selectnum2 = 0;
    public Socket selectSecket;
    public Socket selectSecket2;

    public bool selectRun = true;
    #endregion 변수

    private void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
        ParentObj = GameObject.Find("PanelBlockCoding").gameObject.transform.Find("CodingPanel").gameObject.transform.Find("CodingMaskPanel").gameObject;
        colliders = this.GetComponents<Collider2D>();

        this.transform.position = new Vector3(930, 421);

        if (colliders != null)
        {
            DownCollider = colliders[0];

            UpCollider = colliders[1];
        }
        selectSecket = arduino.PinList[0];
        selectSecket2 = arduino.PinList[0];
    }

    #region 필수 구현 부분
    public override IEnumerator Run(float s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        GetChild = false;

        if (selectSecket2 != null && selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:

                    selectSecket.SocketRun(0);

                    break;

                    //  selectSecket.SocketRun(0);
            }

            switch (selectSecket2.SocketType)
            {
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:

                    float? value = selectSecket2.floatSocketRun();
                    float value3 = float.Parse(value.ToString());

                    GameManager.Setdistancetext("핀" + selectnum + " : " + Mathf.RoundToInt(value3) + "cm");
                    GameManager.distance = value;

                    break;

                    //  selectSecket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.Run(0));
            GetChild = true;
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
        

        GameManager.DigitalWrite(selectnum.ToString() + selectnum2.ToString());

        yield return new WaitForSecondsRealtime(2f);
        GameManager.ReadArduinoValue();

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.SyncRun(s));
            GetChild = true;
        }

        if (GetChild == false)
        {
            GameManager.closeArduino();
            GameManager.SyncRun();
        }
    }


    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;
        if (selectSecket2 != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket2.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        UltCode();
                        break;
                }
            }
        }

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.MergeCode();
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;
        if (selectSecket2 != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket2.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        syncUltCode();
                        break;
                }
            }
        }

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncMergeCode();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;
        if (selectSecket2 != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket2.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        syncBTUltCode();
                        break;
                }
            }
        }

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncBTMergeCode();
        }
    }
    #endregion 필수 구현 부분

    #region 고유 구현 부분

    public void UltCode()
    {
        GameManager.AddValueLis("long duration=0;\n");
        GameManager.AddValueLis("long distance=0;\n");
        GameManager.Addsetup("Serial.begin(9600);");
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");
        GameManager.Addsetup("pinMode(" + selectnum2 + ",INPUT);");
        GameManager.loop.Add("digitalWrite(" + selectnum + ",HIGH);\n");
        GameManager.loop.Add("delay(100);\n");
        GameManager.loop.Add("digitalWrite(" + selectnum + ",LOW);\n");
        GameManager.loop.Add("duration=pulseIn(" + selectnum2 + ",HIGH);\n");
        GameManager.loop.Add("distance=duration/58.2;\n");
        GameManager.loop.Add("Serial.println(distance);");
    }

    public void syncUltCode()
    {
        GameManager.AddValueLis("long duration=0;\n");
        GameManager.AddValueLis("long distance=0;\n");
        GameManager.Addsetup("Serial.begin(9600);");
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");
        GameManager.Addsetup("pinMode(" + selectnum2 + ",INPUT);");

        string loopsentence = string.Format("");

        loopsentence += "if(sync==" + '"' + selectnum + selectnum2 + '"' + ")\n{";
        loopsentence += "digitalWrite(" + selectnum + ",HIGH);\n";
        loopsentence += "delay(100);\n";
        loopsentence += "digitalWrite(" + selectnum + ",LOW);\n";
        loopsentence += "duration=pulseIn(" + selectnum2 + ",HIGH);\n";
        loopsentence += "distance=duration/58.2;\n";
        loopsentence += "Serial.println(distance);\n}";

        GameManager.AddloopList(loopsentence);
    }

    public void syncBTUltCode()
    {
        GameManager.AddValueLis("long duration=0;\n");
        GameManager.AddValueLis("long distance=0;\n");
        GameManager.Addsetup("Serial.begin(9600);");
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");
        GameManager.Addsetup("pinMode(" + selectnum2 + ",INPUT);");

        string loopsentence = string.Format("");

        loopsentence += "if(sync==" + '"' + selectnum + selectnum2 + '"' + ")\n{";
        loopsentence += "digitalWrite(" + selectnum + ",HIGH);\n";
        loopsentence += "delay(100);\n";
        loopsentence += "digitalWrite(" + selectnum + ",LOW);\n";
        loopsentence += "duration=pulseIn(" + selectnum2 + ",HIGH);\n";
        loopsentence += "distance=duration/58.2;\n";
        loopsentence += "btSerial.println(distance);\n}";

        GameManager.AddloopList(loopsentence);
    }

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSecket = arduino.PinList[_num];
    }

    public void GetNum(int num)
    {
        selectnum2 = num;

        selectSecket2 = arduino.PinList[num];
    }

    #endregion 고유 구현 부분
}