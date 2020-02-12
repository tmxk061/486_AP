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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (tableMgr.CreateMode)
            {
                OnReturnBtnClick();
            }
        }
    }

    public void OnCreateBtnClick()
    {
        tableMgr.CreateMode = true;
        guidHud_Mgr.instance.modeChange(1);
        PlayerCamera.SetActive(false);
        CreateCamera.SetActive(true);
        CreateCanvas.SetActive(true);

        PlayZoneCamera.SetActive(false);
    }

    public void OnReturnBtnClick()
    {
        tableMgr.CreateMode = false;
        guidHud_Mgr.instance.modeChange(0);
        PlayerCamera.SetActive(true);
        CreateCamera.SetActive(false);
        CreateCanvas.SetActive(false);

        PlayZoneCamera.SetActive(true);


    }
}
