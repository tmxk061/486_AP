using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickMove_Mgr : MonoBehaviour
{
    [SerializeField]
    private GameObject QuickMoveUI;


    [SerializeField]
    private Animator ani;

    [SerializeField]
    private GameObject blockCodingBtn;

    [SerializeField]
    private CreateModeBtn CreatereturnBtn;

    private bool isOn = false;

    [SerializeField]
    private List<Transform> MovePoint;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject CreateBtn;

    [SerializeField]
    private GameObject RunParent;

    [SerializeField]
    private GameObject RunGrrop;

    [SerializeField]
    private GameObject RunBtn;

    [SerializeField]
    private GameObject GetOut;

    [SerializeField]
    private GameObject createCamera;

    [SerializeField]
    private GameObject PlayZoneCamera;

    [SerializeField]
    private GameObject MAinCamera;

    public CraftTable_Mgr tableMgr;

    public GraphicRaycaster EduRay;

    private bool isMoveMode = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetSelectMenu();
        }
    }

    public void SetSelectMenu()
    {
        if (!isOn)
        {
            isOn = true;
            QuickMoveUI.SetActive(true);

            if (Player.GetComponent<Player_Move>().isAct == true)
                isMoveMode = true;

            Player.GetComponent<Player_Move>().isAct = false;
        }
        else if (isOn)
        {
            if (isMoveMode)
            {
                Player.GetComponent<Player_Move>().isAct = true;
                isMoveMode = false;
            }
            isOn = false;
            ActiveeFalse();
            //ani.SetTrigger("Off");
            //Invoke("ActiveeFalse", 0.5f);
        }
    }

    private void ActiveeFalse()
    {
        QuickMoveUI.SetActive(false);
    }

    public void BlockCordingOnclick()
    {
        isMoveMode = false;
        EduRay.enabled = false;
        createCamera.SetActive(false);
        PlayZoneCamera.SetActive(true);
        MAinCamera.SetActive(true);
        //GetOut.GetComponent<OnButtonClick>().Click();
        blockCodingBtn.GetComponent<OnCubeClick>().OnMouseDown();
        isOn = false;
        ActiveeFalse();
    }

    public void WarpPoint(int i)
    {
        isMoveMode = false;
        EduRay.enabled = true;
        GetOut.GetComponent<OnButtonClick>().Click();
        CreatereturnBtn.OnReturnBtnClick();
        Player.transform.position = MovePoint[i-1].position;
        isOn = false;

        if (i == 1)
        {
            Player.GetComponent<Player_Move>().isAct = false;
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Player.GetComponent<Player_Move>().isAct = true;
        }
        ActiveeFalse();
    }

    public void CreateMode()
    {
        isMoveMode = false;
        EduRay.enabled = false;
        isOn = false;
        tableMgr.CreateMode = true;
        GetOut.GetComponent<OnButtonClick>().Click();
        CreateBtn.GetComponent<CreateModeBtn>().OnCreateBtnClick();
        isOn = false;
        Player.GetComponent<Player_Move>().isAct = true;
        ActiveeFalse();
    }

    public void Run()
    {
            RunBtn.GetComponent<RunButton>().OnMouseDown();
            isOn = false;
    }

}
