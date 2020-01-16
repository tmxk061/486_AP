using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSenorEX : MonoBehaviour
{
    public WaterDetect wd;
    public WaterValue wv;

    void Start()
    {
        
    }


    void Update()
    {
        if (wv.AnalogConnect == true && wv.GNDConnect == true && wv.VccConnect == true)
        {
            Debug.Log(wv.value);
        }
    }
}
