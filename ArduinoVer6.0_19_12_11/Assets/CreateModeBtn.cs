using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModeBtn : MonoBehaviour
{
    public CraftTable_Mgr tableMgr;
    public GameObject PlayerCamera;
    public GameObject CreateCamera;
    public GameObject CreateCanvas;


    public void OnCreateBtnClick()
    {
        tableMgr.CreateMode = true;
        PlayerCamera.SetActive(false);
        CreateCamera.SetActive(true);
        CreateCanvas.SetActive(true);
    }

    public void OnReturnBtnClick()
    {
        tableMgr.CreateMode = false;
        PlayerCamera.SetActive(true);
        CreateCamera.SetActive(false);
        CreateCanvas.SetActive(false);

    }
}
