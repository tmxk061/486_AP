using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevTableCtrl : MonoBehaviour
{
    public GameObject ModulCmd;
    private bool isModulCmd = false;

    public GameObject EnvCmd;
    private bool isEnvCmd = false;

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

    public void Ctrl_EnvCmd_Onclick()
    {
        if (isEnvCmd == false)
        {
            EnvCmd.SetActive(true);
            EnvCmd.GetComponent<Animator>().SetBool("EnvCmd_open", true);
            isEnvCmd = true;
        }
        else if (isEnvCmd == true)
        {
            EnvCmd.GetComponent<Animator>().SetBool("EnvCmd_open", false);
            //ModulCmd.SetActive(false);
            Invoke("EnvCmd_ActiveFalse", 1f);
            isEnvCmd = false;
        }
    }


    private void ModulCmd_ActiveFalse()
    {
        ModulCmd.SetActive(false);
    }

    private void EnvCmd_ActiveFalse()
    {
        EnvCmd.SetActive(false);
    }
}
