﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoIll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;
    public GameObject spwnPoint;

    public GameObject Tootip;

    public SensorType type;

    public void ClickEvent()
    {
        IllValue ultval = Instantiate(obj, spwnPoint.transform.position, spwnPoint.transform.rotation).transform.GetChild(0).GetComponent<IllValue>();
        ultval.sensorType = type;
        //ultval.gameObject.transform.parent = GameObject.Find("CraftTable").transform;

        
        //IllValue illval = Instantiate(obj, new Vector3(-40, 115, 35), Quaternion.Euler(90, 0, 0)).transform.Find("DetectLight").GetComponent<IllValue>();
        //illval.sensorType = type;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tootip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tootip.SetActive(false);
    }
}