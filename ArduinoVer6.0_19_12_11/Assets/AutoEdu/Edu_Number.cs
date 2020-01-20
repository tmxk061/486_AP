using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edu_Number : MonoBehaviour
{
    public GameObject parent;
    public int modulNum;
    public int Number;

    private void OnMouseDown()
    {
        Debug.Log("PinNum :" + Number);
        GameObject.Find("Education").GetComponent<Auto_Edu_Mgr>().ClickEvent(new int[] { modulNum, Number},parent);
    }
}
