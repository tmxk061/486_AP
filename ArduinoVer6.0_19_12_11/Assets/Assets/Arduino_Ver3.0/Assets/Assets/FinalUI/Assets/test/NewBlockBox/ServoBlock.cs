using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ServoBlock : Block
{
    #region 변수

    //[SerializeField]
    //public Canvas canvas;
    //[SerializeField]
    //public Camera secondCamera;
    private ControlArduino arduino;
    public int selectnum = 0;
    public Socket selectSocket;
    public bool UpConncet = false;
    public bool DownConnect = false;
    
    public float value = 0f;

    #endregion 변수

    protected override void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();

        base.Start();
    }

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        GetChild = false;
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    selectSocket.SocketRun(value);
                    break;

                    //  selectSocket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.Run(0));
            GetChild = true;
        }

        if (GetChild == false && s == 0)
        {
            GameManager.RunbtnWork();
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;

       
        GameManager.DigitalWrite(selectnum.ToString() + value);

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    selectSocket.SocketRun(value);
                    break;

                    //  selectSocket.SocketRun(0);
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

        if (GetChild == false && s == true)
        { GameManager.closeArduino(); GameManager.SyncRun(); }
    }
    

    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    ServoRunCode();
                    break;

                    //  selectSocket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode(); GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;

        if (selectSocket != null)
        {
            switch (selectSocket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    syncServoRunCode();
                    break;

                    //  selectSocket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(1f);

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
                case GameManager.SensorType.Servo:
                    syncServoRunCode();
                    break;

                    //  selectSocket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(1f);

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

    #endregion 필수 구현 부분


    #region 고유 구현 부분

    private void ServoRunCode()
    {
        GameManager.AddHeader("#include<Servo.h>");
        GameManager.AddValueLis("Servo servo;");
        GameManager.Addsetup("servo.attach(" + selectnum + ");");

        GameManager.loop.Add("servo.write(" + value + ");");
    }

    private void syncServoRunCode()
    {
        GameManager.AddHeader("#include<Servo.h>");
        GameManager.AddValueLis("Servo servo;");

        GameManager.Addsetup("servo.attach(" + selectnum + ");");
        GameManager.loop.Add("if(sync==" + '"' + selectnum + value + '"' + ")\n{");
        GameManager.loop.Add("servo.write(" + value + ");");
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");
    }

    private void syncBTServoRunCode()
    {
        GameManager.AddHeader("#include<Servo.h>");
        GameManager.AddValueLis("Servo servo;");

        GameManager.Addsetup("servo.attach(" + selectnum + ");");
        GameManager.loop.Add("if(sync==" + '"' + selectnum + value + '"' + ")\n{");
        GameManager.loop.Add("servo.write(" + value + ");");
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");
    }

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSocket = arduino.PinList[_num];
    }

    public void setAngle(float s)
    {
        value = s;
    }

    #endregion 고유 구현 부분
}