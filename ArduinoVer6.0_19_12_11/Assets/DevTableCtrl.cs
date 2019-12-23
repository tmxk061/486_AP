using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevTableCtrl : MonoBehaviour
{
    public GameObject ModulCmd;
    private bool isModulCmd = false;

    public void Ctrl_ModulCmd_Onclick()
    {
        if (isModulCmd == false)
        {
            ModulCmd.SetActive(true);
            ModulCmd.GetComponent<Animator>().SetBool("Modul_open", true);
            isModulCmd = true;
        }
        else if (isModulCmd == true)
        {
            ModulCmd.GetComponent<Animator>().SetBool("Modul_open", false);
            //ModulCmd.SetActive(false);
            Invoke("ModulCmd_ActiveFalse", 1f);
            isModulCmd = false;
        }
    }


    private void ModulCmd_ActiveFalse()
    {
        ModulCmd.SetActive(false);
    }
}
