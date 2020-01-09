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
    private GameObject[] NormalguidUI; // 0.노말 1.고정노말

    [SerializeField]
    private GameObject Normalguid; 

    [SerializeField]
    private GameObject Craftguid;


    public void changeGuide(int num)
    {
        for (int i = 0; i < NormalguidUI.Length; i++)
        {
            if (i == num)
            {
                NormalguidUI[i].SetActive(true);
                continue;
            }

            NormalguidUI[i].SetActive(false);
        }
    }

    public void modeChange(int i)
    {
        //0.노말모드 가이드, 1.조립모드 가이드

        if (i == 0)
        {
            Normalguid.SetActive(true);
            Craftguid.SetActive(false);
        }
        if (i == 1)
        {
            Normalguid.SetActive(false);
            Craftguid.SetActive(true);
        }
    }
}
