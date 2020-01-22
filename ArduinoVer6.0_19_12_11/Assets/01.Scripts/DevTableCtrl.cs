using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevTableCtrl : MonoBehaviour
{
    public GameObject ModulCmd;
    public bool isModulCmd = false;
    private Vector3 ModulFirstPos;
    public GraphicRaycaster ModulCmdCanvas;

    public GameObject EnvCmd;
    public bool isEnvCmd = false;
    private Vector3 EnvFirstPos;
    public GraphicRaycaster EnvCmdCmdCanvas;


    //private void Start()
    //{
    //    ModulCmd.GetComponent<Animator>().SetBool("Modul_open", false);
    //    ModulFirstPos = ModulCmd.transform.localPosition;
    //    EnvFirstPos = EnvCmd.transform.localPosition;
    //}

    //private void OnEnable()
    //{
    //    Debug.Log("asd");
    //}

    public void Ctrl_ModulCmd_Onclick()
    {
        if (isModulCmd == false)
        {
            ModulCmd.SetActive(true);
            ModulCmd.GetComponent<Animator>().SetBool("Modul_open", true);
            isModulCmd = true;
            ModulCanvasSet(true);
        }
        else if (isModulCmd == true)
        {
            ModulCmd.GetComponent<Animator>().SetBool("Modul_open", false);
            //ModulCmd.SetActive(false);
            //Invoke("ModulCmd_ActiveFalse", 1f);
            isModulCmd = false;
            ModulCanvasSet(false);
        }
    }

    public void Ctrl_EnvCmd_Onclick()
    {
        if (isEnvCmd == false)
        {
            EnvCmd.SetActive(true);
            EnvCmd.GetComponent<Animator>().SetBool("EnvCmd_open", true);
            isEnvCmd = true;
            EnvCmdCmdCanvasSet(true);


        }
        else if (isEnvCmd == true)
        {
            EnvCmd.GetComponent<Animator>().SetBool("EnvCmd_open", false);
            //ModulCmd.SetActive(false);
            //Invoke("EnvCmd_ActiveFalse", 1f);
            isEnvCmd = false;
            EnvCmdCmdCanvasSet(false);



        }
    }

    //public void ResetStat()
    //{
    //    ModulCmd.GetComponent<Animator>().SetBool("Modul_open", false);
    //    ModulCmd.transform.localPosition = ModulFirstPos;
    //    EnvCmd.transform.localPosition = EnvFirstPos;

    //    ModulCmd.SetActive(false);
    //    ModulCmd.SetActive(true);
    //}

    private void ModulCmd_ActiveFalse()
    {
        ModulCmd.SetActive(false);
    }

    private void EnvCmd_ActiveFalse()
    {
        EnvCmd.SetActive(false);
       
    }

    public void ModulCanvasSet(bool check)
    {
        ModulCmdCanvas.enabled = check;
    }

    public void EnvCmdCmdCanvasSet(bool check)
    {
        EnvCmdCmdCanvas.enabled = check;
    }
}
