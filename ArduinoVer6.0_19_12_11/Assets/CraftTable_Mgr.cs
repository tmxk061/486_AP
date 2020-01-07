using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTable_Mgr : MonoBehaviour
{
    public static CraftTable_Mgr instance;
    public void Awake()
    {
        CraftTable_Mgr.instance = this;
    }

    public bool CreateMode = false;
}
