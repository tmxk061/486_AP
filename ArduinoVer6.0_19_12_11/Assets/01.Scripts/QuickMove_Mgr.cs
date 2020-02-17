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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOn)
            {
                isOn = true;
                QuickMoveUI.SetActive(true);
            }
            else if(isOn)
            {
                isOn = false;
                ani.SetTrigger("Off");
                Invoke("ActiveeFalse", 0.5f);
            }
        }
    }

    private void ActiveeFalse()
    {
        QuickMoveUI.SetActive(false);
    }

    public void BlockCordingOnclick()
    {
        GetOut.GetComponent<OnButtonClick>().Click();
        blockCodingBtn.GetComponent<OnCubeClick>().OnMouseDown();
        isOn = false;
        ActiveeFalse();
    }

    public void WarpPoint(int i)
    {
        GetOut.GetComponent<OnButtonClick>().Click();
       Player.transform.position = MovePoint[i-1].position;
        isOn = false;
        ActiveeFalse();

    }

    public void CreateMode()
    {
        GetOut.GetComponent<OnButtonClick>().Click();
        CreateBtn.GetComponent<CreateModeBtn>().OnCreateBtnClick();
        isOn = false;
        ActiveeFalse();
    }

    public void Run()
    {
      
            RunBtn.GetComponent<RunButton>().OnMouseDown();
            isOn = false;
            ActiveeFalse();
    }

}
