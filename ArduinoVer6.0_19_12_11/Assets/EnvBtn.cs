using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvBtn : MonoBehaviour
{
    public GameObject EnvUI;
    private bool isOn = false;

    public void OnclickBtn()
    {
        if (isOn == false)
        {
            EnvUI.SetActive(true);
            isOn = true;
        }
        else
        {
            EnvUI.SetActive(false);
            isOn = false;
        }
    }
}
