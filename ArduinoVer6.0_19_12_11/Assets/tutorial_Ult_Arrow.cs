using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_Ult_Arrow : MonoBehaviour
{
    public static tutorial_Ult_Arrow instance;
    public void Awake()
    {
        tutorial_Ult_Arrow.instance = this;
    }

    [SerializeField]
    private GameObject Arrow;

    public void SetEnable(bool b)
    {
        Arrow.SetActive(b);
    }
}
