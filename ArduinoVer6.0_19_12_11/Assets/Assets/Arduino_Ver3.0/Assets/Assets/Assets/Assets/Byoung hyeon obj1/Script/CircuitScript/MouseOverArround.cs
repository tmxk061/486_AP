using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverArround : MonoBehaviour
{
    public GameObject MakeLine;
    public Mousepoint mousepoint;

    LineArray la;

    public GameObject Parents;

    //이곳에서 선을 만들어준다.
    private void Start()
    {
        MakeLine = Resources.Load("LineManager") as GameObject;
        mousepoint = Camera.main.GetComponent<Mousepoint>();
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
        if (mousepoint.MouseChecking == false)
        {
            mousepoint.MouseChecking = true;
            MakeLine = (GameObject)Instantiate(MakeLine, transform.position, this.gameObject.transform.rotation) as GameObject;
            MakeLine.GetComponentInChildren<line>().gameObject.GetComponent<LineRenderer>().material.color = Random.ColorHSV();
            Parents.GetComponent<LineArray>().array.Add(MakeLine);

            MakeLine.transform.parent = GameObject.Find("DevTable").transform;
        }
        else
            mousepoint.MouseChecking = false;

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
