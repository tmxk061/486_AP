using UnityEngine;
using UnityEngine.UI;

public class TutorialMgr : MonoBehaviour
{
    [SerializeField]
    public GameObject TutorialObj; //전체 튜토리얼 오브젝트를 담은 오브젝트

    [SerializeField]
    public GameObject TextBox; // 텍스트 박스 UI

    [SerializeField]
    public Text TextBoxText;//텍스트 박스의 텍스트

    private int Flow;
    private int FlowNum;

    private bool isStart = false;

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
                SetTextBox("그렇다면 다행이긴한데");
                NextFlow(1);
                break;

            default:
                EndTutorial();
                break;
        }
    }

    private void NextFlow(int i)
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

    } //다음 흐름으로 넘어가는 조건

    private void SetTextBox(string msg)
    {
        TextBoxText.text = msg;
    }
}