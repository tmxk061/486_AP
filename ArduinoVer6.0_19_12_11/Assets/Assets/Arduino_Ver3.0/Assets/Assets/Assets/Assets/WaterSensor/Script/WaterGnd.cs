using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGnd : PlusMinus
{
    public int VccPower = 0;
    public float Electro;

    public GameObject Around;
    //public LineManager Line;
    LineManager Line;
    WaterValue watervalue;
    bool LineCheck = false;
    Transform LineObject;
    // Start is called before the first frame update
    void Start()
    {
        watervalue = GetComponentInParent<WaterValue>();
        OnArround(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && watervalue.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && watervalue.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line")
        {
            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            if (Line.parent != null)
            {

                if (Line.parent.tag == "GND")
                {


                    watervalue.GNDConnect = true;


                }
                else if (Line.parent.tag == "BreadGND")
                {

                    watervalue.GNDConnect = true;

                }
                //================================================
                //else if (LineCheck == true)
                //{
                //    OnArround(true);
                //}
                //================================================

            }
        }
    }

    public override void OnArround(bool b)
    {
        try
        {
            Around.SetActive(b);

            if (b == true)
            { watervalue.GNDConnect = false; }
            //=================================================
            //else if (illvalue.MouseClick == true)
            //{
            //    LineObject.transform.position = Around.transform.position;
            //}
            //=================================================

        }
        catch (Exception)
        {
            Func(delegate () { return true; });
        }
    }

    void Func(Func<bool> callback)
    {
        callback();
    }
}
