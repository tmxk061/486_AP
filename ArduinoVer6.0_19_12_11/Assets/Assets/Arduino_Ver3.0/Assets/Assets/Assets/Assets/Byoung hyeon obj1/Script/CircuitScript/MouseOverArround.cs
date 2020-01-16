using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverArround : MonoBehaviour
{
    public GameObject MakeLine;
    public Mousepoint mousepoint;
    public Mousepoint mousepoint2;

    public CraftTable_Mgr tableMgr;

    LineArray la;

    public GameObject Parents;

    //이곳에서 선을 만들어준다.
    private void Start()
    {
        MakeLine = Resources.Load("LineManager") as GameObject;
        mousepoint = Camera.main.GetComponent<Mousepoint>();
        mousepoint2 = GameObject.Find("CreateCameras").transform.GetChild(0).GetComponent<Mousepoint>();
        tableMgr = GameObject.Find("CraftTable").GetComponent<CraftTable_Mgr>();
    }

    private void Update()
    {
        if (MakeLine == false)
        {
            MakeLine = Resources.Load("LineManager") as GameObject;
        }
    }

    public void OnMouseDown()
    {
        if (tableMgr.CreateMode == false)
        {
            if (mousepoint.MouseChecking == false)
            {
                mousepoint.MouseChecking = true;
                MakeLine = (GameObject)Instantiate(MakeLine, transform.position, this.gameObject.transform.rotation) as GameObject;
                MakeLine.GetComponentInChildren<line>().gameObject.GetComponent<LineRenderer>().material.color = Random.ColorHSV();
                Parents.GetComponent<LineArray>().array.Add(MakeLine);

                MakeLine.transform.parent = GameObject.Find("TableSensors").transform;
            }
            else
                mousepoint.MouseChecking = false;
        }
        else if (tableMgr.CreateMode == true)
        {
            if (mousepoint2.MouseChecking == false)
            {
                mousepoint2.MouseChecking = true;
                MakeLine = (GameObject)Instantiate(MakeLine, transform.position, this.gameObject.transform.rotation) as GameObject;
                //MakeLine.GetComponentInChildren<line>().gameObject.GetComponent<LineRenderer>().material.color = Random.ColorHSV();
                MakeLine.GetComponentInChildren<line>().gameObject.GetComponent<LineRenderer>().material.color = new Color(255, 0, 0);
                Parents.GetComponent<LineArray>().array.Add(MakeLine);

                MakeLine.transform.parent = GameObject.Find("TableSensors").transform;
            }
            else
                mousepoint2.MouseChecking = false;
        }
    }


    public void OnMouseEnter()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void OnMouseExit()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void OnDisable()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }


}
