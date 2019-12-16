﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298N_MANAGER : MonoBehaviour
{

    public bool VccConnect { get; set; }
    public bool GNDConnect { get; set; }
    public bool DigitalConnect1 { get; set; }
    public bool DigitalConnect2 { get; set; }
    public bool DigitalConnect3 { get; set; }
    public bool DigitalConnect4 { get; set; }
    public int POWER { get; set; }

    public List<L298NOUT4> outlist;
    float distance = 10;
    public bool MouseClick = false;

    // Start is called before the first frame update
    void Start()
    {
        outlist.Add(transform.Find("OUT1").GetComponent<L298NOUT4>());
        outlist.Add(transform.Find("OUT2").GetComponent<L298NOUT4>());
        outlist.Add(transform.Find("OUT3").GetComponent<L298NOUT4>());
        outlist.Add(transform.Find("OUT4").GetComponent<L298NOUT4>());

        VccConnect = false;
        GNDConnect = false;
        DigitalConnect1 = false;
        DigitalConnect2 = false;
        DigitalConnect3 = false;
        DigitalConnect4 = false;
        POWER = 0;
    }

    #region MouseDrag
    private void OnMouseDown()
    {
        distance = this.transform.position.z - Camera.main.transform.position.z;
    }

    private void OnMouseUp()
    {
        MouseClick = false;
    }

    void OnMouseDrag()
    {
        MouseClick = true;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance -= 10;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance += 10;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Sensor"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}

        //if (Input.GetKey(KeyCode.E))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}

    }
    #endregion
}
