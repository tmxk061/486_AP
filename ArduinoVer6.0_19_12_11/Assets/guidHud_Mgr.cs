using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidHud_Mgr : MonoBehaviour
{
    public static guidHud_Mgr instance;
    public void Awake()
    {
        guidHud_Mgr.instance = this;
    }

    [SerializeField]
    private GameObject[] guidUI; // 0.노말 1.고정노말 2.크래프트


    public void changeGuide(int num)
    {
        for (int i = 0; i < guidUI.Length; i++)
        {
            if (i == num)
            {
                guidUI[i].SetActive(true);
                continue;
            }

            guidUI[i].SetActive(false);
        }
    }
}
