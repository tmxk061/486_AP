﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLight : MonoBehaviour
{
    public TextMesh luxvalue;

    public GameObject[] light;

    public GameObject Onlight;
    public GameObject Offlight;

    bool mlight;

    void Start()
    { 
        mlight = false;

        Onlight.SetActive(false);
        Offlight.SetActive(true);

        light = GameObject.FindGameObjectsWithTag("MissionLight");

        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(false);
        }
    }

    private void Update()
    {
        lux();
    }

    void lux()
    {
        if (luxvalue.text != "")
        {
            Debug.Log("on3");
            if (mlight == false)
            {
                Debug.Log("on4");
                mlight = true;
                Onlight.SetActive(true);
                Offlight.SetActive(false);
                TurnOnLight();

            }
        }     
    }
    void TurnOnLight()
    {
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(true);
        }
    }

}
