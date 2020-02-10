using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMgr : MonoBehaviour
{
    [SerializeField]
    public GameObject TextBox;

    [SerializeField]
    public Text TextBoxText;

    private int FlowNum;

    private void Start()
    {
        StartCoroutine(TutorialRogic());
    }


    IEnumerator TutorialRogic()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FlowNum++;
                TutorialFlow_1();
            }
        }
    }

  
    public void TutorialFlow_1()
    {
        switch (FlowNum)
        {
            case 1:
                SetTextBox("튜토리얼을 테스트 하는 중입니다.");
                break;
            case 2:
                SetTextBox("튜토리얼이 잘 보이시나요?");
                break;
            case 3:
                SetTextBox("그렇다면 다행이긴한데");
                break;
            default:
                resetFlowNum();
                break;
        }
    }


    private void SetTextBox(string msg)
    {
        TextBoxText.text = msg;
    }

    private void resetFlowNum()
    {
        FlowNum = 0;
    }
}
