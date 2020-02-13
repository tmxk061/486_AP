﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edu_Number : MonoBehaviour
{
    public GameObject parent;
    public int modulNum;
    public int Number;

    private void OnMouseDown()
    {
        if (!GameObject.Find("Player").GetComponent<Player_Move>().isAct)
            return;

        if (Number > 999)
        {
            GameObject.Find("Education").GetComponent<Auto_Edu_Mgr>().ClickEvent(new int[] { modulNum, Number-1000 }, parent);
        }
        else
            GameObject.Find("Education").GetComponent<Auto_Edu_Mgr>().ClickEvent(new int[] { modulNum, Number}, parent);
    }
}
