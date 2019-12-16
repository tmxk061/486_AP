﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalogRead : Block
{
    #region 변수

    //[SerializeField]
    //public Canvas canvas;
    //[SerializeField]
    //public Camera secondCamera;

    public int selectnum = 0;
    public Socket selectSecket;

    public bool selectRun = true;
    public bool UpConncet = false;
    public bool DownConnect = false;
    
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
    }

    #region 필수 구현 부분
    public override IEnumerator Run(float s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;
        if (selectSecket != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:

                        float? value = selectSecket.floatSocketRun();
                        float value3 = float.Parse(value.ToString());

                        GameManager.Setdistancetext("핀" + selectnum + " : " + Mathf.RoundToInt(value3) + "cm");
                        GameManager.distance = value;

                        break;

                    case GameManager.SensorType.HumiTemp:

                        List<float> temphumilist = new List<float>();

                        temphumilist = selectSecket.listSocketRun();

                        GameManager.temp = temphumilist[0];
                        GameManager.humi = temphumilist[1];

                        float value1 = float.Parse(GameManager.temp.ToString());
                        float value2 = float.Parse(GameManager.humi.ToString());
                        GameManager.SetTemptext("핀" + selectnum + " : " + Mathf.RoundToInt(value1));
                        GameManager.SetHumitext("핀" + selectnum + " : " + Mathf.RoundToInt(value2));
                        break;

                    case GameManager.SensorType.Lux:

                        float? valuelux = selectSecket.floatSocketRun();

                        GameManager.setLuxtext("핀" + selectnum + " : " + valuelux);
                        GameManager.lux = valuelux;

                        break;

                        //  selectSecket.SocketRun(0);
                }
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
        Block block = null;

        if (selectnum == 14)
        {
            GameManager.DigitalWrite("A0");
        }
        else if (selectnum == 15)
        {
            GameManager.DigitalWrite("A1");
        }
        else if (selectnum == 16)
        {
            GameManager.DigitalWrite("A2");
        }
        else if (selectnum == 17)
        {
            GameManager.DigitalWrite("A3");
        }
        else if (selectnum == 18)
        {
            GameManager.DigitalWrite("A4");
        }
        else if (selectnum == 19)
        {
            GameManager.DigitalWrite("A5");
        }
        else
        {
            GameManager.DigitalWrite(selectnum.ToString());
        }

        yield return new WaitForSecondsRealtime(1f);

        GameManager.ReadLuxArduinoValue();

        block = BlockManager.instance.BlockIdentity(transform);
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
        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:

                    break;

                case GameManager.SensorType.HumiTemp:
                    HumiTemp();
                    break;

                case GameManager.SensorType.Lux:
                    LuxCode();
                    break;
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
        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서

                case GameManager.SensorType.HumiTemp:
                    syncHumiTemp();
                    break;

                case GameManager.SensorType.Lux:
                    syncLuxCode();
                    break;
            }
        }

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncMergeCode();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;
        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서

                case GameManager.SensorType.HumiTemp:
                    syncBTHumiTemp();
                    break;

                case GameManager.SensorType.Lux:
                    syncBTLuxCode();
                    break;
            }
        }

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncBTMergeCode();
        }
    }
    #endregion 필수 구현 부분


    #region 고유 구현 부분
    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSecket = arduino.PinList[_num];
    }

    public void HumiTemp()
    {
        GameManager.AddHeader("#" + "include " + "DHT.h");
        GameManager.AddValueLis("#" + "define " + "DHTPIN " + selectnum);
        GameManager.AddValueLis("#" + "define " + "DHTTYPE " + "DHT11");
        GameManager.AddValueLis("DHT dht(DHTPIN,DHTTYPE);");

        GameManager.loop.Add("humi= dht.readHumidity();");
        GameManager.loop.Add("temp=dht.readTemperature();");
    }

    public void syncHumiTemp()
    {
        GameManager.AddHeader("#" + "include " + "DHT.h");
        GameManager.AddValueLis("#" + "define " + "DHTPIN " + selectnum);
        GameManager.AddValueLis("#" + "define " + "DHTTYPE " + "DHT11");
        GameManager.AddValueLis("DHT dht(DHTPIN,DHTTYPE);");
        GameManager.loop.Add("if(sync==" + selectnum + ")\n{");
        GameManager.loop.Add("float humi= dht.readHumidity();");
        GameManager.loop.Add("float temp=dht.readTemperature();");
        GameManager.loop.Add("Serial.println(humi);");
        GameManager.loop.Add("Serial.println(temp);");
        GameManager.loop.Add("\n}");
    }

    public void syncBTHumiTemp()
    {
        GameManager.AddHeader("#" + "include " + "DHT.h");
        GameManager.AddValueLis("#" + "define " + "DHTPIN " + selectnum);
        GameManager.AddValueLis("#" + "define " + "DHTTYPE " + "DHT11");
        GameManager.AddValueLis("DHT dht(DHTPIN,DHTTYPE);");
        GameManager.loop.Add("if(sync==" + selectnum + ")\n{");
        GameManager.loop.Add("float humi= dht.readHumidity();");
        GameManager.loop.Add("float temp=dht.readTemperature();");
        GameManager.loop.Add("btSerial.println(humi)");
        GameManager.loop.Add("btSerial.println(temp)");
        GameManager.loop.Add("\n}");
    }

    public void LuxCode()
    {
        GameManager.AddValueLis("int lux=0;");

        if (selectnum == 14)
            GameManager.loop.Add("lux=analogRead(A0);");
        else if (selectnum == 15)
            GameManager.loop.Add("lux=analogRead(A1);");
        else if (selectnum == 16)
            GameManager.loop.Add("lux=analogRead(A2);");
        else if (selectnum == 17)
            GameManager.loop.Add("lux=analogRead(A3);");
        else if (selectnum == 18)
            GameManager.loop.Add("lux=analogRead(A4);");
        else if (selectnum == 19)
            GameManager.loop.Add("lux=analogRead(A5);");
    }

    public void syncLuxCode()
    {
        GameManager.AddValueLis("int lux=0;");

        if (selectnum == 14)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A0" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A0);");
        }
        else if (selectnum == 15)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A1" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A1);");
        }
        else if (selectnum == 16)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A2" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A2);");
        }
        else if (selectnum == 17)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A3" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A3);");
        }
        else if (selectnum == 18)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A4" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A4);");
        }
        else if (selectnum == 19)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A5" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A5);");
        }

        GameManager.loop.Add("\nSerial.println(lux);");
        GameManager.loop.Add("\n}\n");
        GameManager.loop.Add("\n");
    }

    public void syncBTLuxCode()
    {
        GameManager.AddValueLis("int lux=0;");

        if (selectnum == 14)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A0" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A0);");
        }
        else if (selectnum == 15)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A1" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A1);");
        }
        else if (selectnum == 16)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A2" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A2);");
        }
        else if (selectnum == 17)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A3" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A3);");
        }
        else if (selectnum == 18)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A4" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A4);");
        }
        else if (selectnum == 19)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A5" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A5);");
        }

        GameManager.loop.Add("\nbtSerial.println(lux);");
        GameManager.loop.Add("\n}\n");
        GameManager.loop.Add("\n");
    }
    #endregion 고유 구현 부분
}