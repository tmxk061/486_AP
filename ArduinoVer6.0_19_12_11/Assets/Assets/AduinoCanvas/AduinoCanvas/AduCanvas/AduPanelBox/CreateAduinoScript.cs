﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;
    public GameObject spwnPoint;

    public GameObject Tootip;

    public void Start()
    {
     
    }

    public void ClickEvent()
    {
        int num = 0;

         num = Random.Range(0, 4);

        GameObject createObj = Instantiate(obj, spwnPoint.transform.position, spwnPoint.transform.rotation);
        createObj.gameObject.transform.parent = GameObject.Find("TableSensors").transform;
        createObj.SetActive(true);
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
