using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialMgr : MonoBehaviour
{
    public static TutorialMgr instance;
    public void Awake()
    {
        TutorialMgr.instance = this;
    }


    [SerializeField]
    public GameObject TutorialObj; //전체 튜토리얼 오브젝트를 담은 오브젝트

    [SerializeField]
    public GameObject TextBox; // 텍스트 박스 UI

    [SerializeField]
    public Text TextBoxText;//텍스트 박스의 텍스트

    private int Flow; //현재 흐름
    public int FlowNum; // 흐름의 순번

    public bool isStart = false; //현재 튜토리얼 작동중인지 여부

    public int OutTrigger; // 작동될 외부 트리거



    public void StartTutorial(int i)
    {
        TutorialObj.SetActive(true);
        Flow = i;
        FlowNum = 1;
        isStart = true;
    }

    public void EndTutorial()
    {
        TutorialObj.SetActive(false);

        FlowNum = 0;
        Flow = 0;
        isStart = false;
    }

    private void Start()
    {
        StartTutorial(1);
    }

    private void Update()
    {
        if (isStart)
        {
            TutorialFlow();
        }
    }

    private void TutorialFlow()
    {
        switch (Flow)
        {
            case 1:
                Tutorial_1();
                break;
        }
    }

    

    private void Tutorial_1()
    {
        switch (FlowNum)
        {
            case 1:
                SetTextBox("튜토리얼을 테스트 하는 중입니다.");
                NextFlow(1);
                break;

            case 2:
                SetTextBox("튜토리얼이 잘 보이시나요?");
                NextFlow(1);
                break;

            case 3:
                SetTextBox("칠판을 향해 가봅시다.");
                NextFlow(1);
                break;

            case 4:
                TextBoxActive(false);
                OutTrigger = 2;
                break;

            case 5:
                TextBoxActive(true);
                SetTextBox("잘했어요!");
                NextFlow(1);
                break;

            default:
                EndTutorial();
                break;
        }
    }

    private void NextFlow(int i) //다음 흐름으로 넘어가는 조건
    {
        switch (i)
        {
            case 1: //마우스 왼쪽 클릭
                if (Input.GetMouseButtonDown(0))
                {
                    FlowNum++;
                }
                break;
        }

    }

    private void SetTextBox(string msg) //텍스트 박스에 텍스트 업데이트
    {
        TextBoxText.text = msg;
    }

    private void TextBoxActive(bool b) // 텍스트박스 오브젝트 활성,비활성화
    {
        TextBox.SetActive(b);
    }
}