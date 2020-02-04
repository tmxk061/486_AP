using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSensor : MonoBehaviour
{
    public static ConfirmSensor instance;
    public void Awake()
    {
        ConfirmSensor.instance = this;
    }


    //public Canvas confirmcanvas;
    public Text moduleName;
    public Canvas confirmcan;
    
    //초음파센서 버튼 누를때
    public void CreateUlt()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "초음파 센서가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //온습도센서 버튼 누를때
    public void Createtemphumi()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "온습도 센서가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //조도센서 버튼 누를 때
    public void Createill()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "조도 센서가 생성되었습니다.";
        StartCoroutine(Delay());
    }
    
    //서보모터 버튼 누를 때
    public void CreateSurvo()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "서보 모터가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //DC모터 버튼 누를 때
    public void CreateDC()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "DC 모터가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //buzzer 버튼 누를 때
    public void Createbuzzer()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "부저가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //LED 버튼 누를 때
    public void CreateLED()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "LED가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //BreadBoard 버튼 누를 때
    public void CreateBreadBoard()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "BreadBoard가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    //L298N 버튼 누를 때
    public void CreateL298N()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "L298N이 생성되었습니다.";
        StartCoroutine(Delay());
    }

    public void CreateWaterSensor()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "수위센서가 생성되었습니다.";
        StartCoroutine(Delay());
    }

    public void BadAnser()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "다시 연결해보세요";
        StartCoroutine(Delay());
    }

    public void GoodAnser()
    {
        confirmcan.gameObject.SetActive(true);
        moduleName.text = "잘했어요!";
        StartCoroutine(Delay());
    }

    //2초 딜레이
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.0f);
        confirmcan.gameObject.SetActive(false);
    }
}
