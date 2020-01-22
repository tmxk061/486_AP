using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModeBtn : MonoBehaviour
{
    public CraftTable_Mgr tableMgr;
    public GameObject PlayerCamera;
    public GameObject CreateCamera;
    public GameObject CreateCanvas;

    public GameObject PlayZoneCamera;

    public DevTableCtrl devTableCtrl;


    public void OnCreateBtnClick()
    {
        tableMgr.CreateMode = true;
        guidHud_Mgr.instance.modeChange(1);
        PlayerCamera.SetActive(false);
        CreateCamera.SetActive(true);
        CreateCanvas.SetActive(true);

        PlayZoneCamera.SetActive(false);

        if (devTableCtrl.isModulCmd == true)
        {
            devTableCtrl.ModulCanvasSet(false);
        }

        if (devTableCtrl.isEnvCmd == true)
        {
            devTableCtrl.EnvCmdCmdCanvasSet(false);
        }
    }

    public void OnReturnBtnClick()
    {
        tableMgr.CreateMode = false;
        guidHud_Mgr.instance.modeChange(0);
        PlayerCamera.SetActive(true);
        CreateCamera.SetActive(false);
        CreateCanvas.SetActive(false);

        PlayZoneCamera.SetActive(true);

        if (devTableCtrl.isModulCmd == true)
        {
            devTableCtrl.ModulCanvasSet(true);
        }

        if (devTableCtrl.isEnvCmd == true)
        {
            devTableCtrl.EnvCmdCmdCanvasSet(true);
        }

    }
}
