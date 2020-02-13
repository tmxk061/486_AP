using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSetting : MonoBehaviour
{
    private void Awake()
    {
        GameManager.temptext = GameObject.Find("TempValue").GetComponent<TextMesh>();
        GameManager.humitext = GameObject.Find("HumiValue").GetComponent<TextMesh>();
        GameManager.distancetext = GameObject.Find("DistanceValue").GetComponent<TextMesh>();
        GameManager.Luxtext = GameObject.Find("LuxValue").GetComponent<TextMesh>();
        GameManager.watertext = GameObject.Find("WaterValue1").GetComponent<TextMesh>();
    }
}
