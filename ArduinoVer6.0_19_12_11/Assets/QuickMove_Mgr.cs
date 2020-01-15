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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isOn)
            {
                isOn = true;
                QuickMoveUI.SetActive(true);
            }
            else if(isOn)
            {
                isOn = false;
                ani.SetTrigger("off");
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
        isOn = false;
        ActiveeFalse();
        blockCodingBtn.GetComponent<OnCubeClick>().OnMouseDown();

    }

}
