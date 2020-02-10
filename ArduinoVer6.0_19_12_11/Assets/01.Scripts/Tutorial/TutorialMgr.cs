using UnityEngine;
using System.Collections;
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

    [SerializeField]
    private List<GameObject> MovePointList;

    private int Flow; //현재 흐름
    public int FlowNum; // 흐름의 순번

    public bool isStart = false; //현재 튜토리얼 작동중인지 여부

    public int OutTrigger; // 작동될 외부 트리거

    public bool doNotClick = false; //모듈 클리과 겹침 방지


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

        if (doNotClick == true)
        {
            Invoke("donotClickFalse", 0.1f);
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
                SetTextBox("안녕하세요! Adu-Class !! 에 오신걸 환영합니다!");
                NextFlow(1);
                break;

            case 2:
                SetTextBox("지금부터 이 작은 교실 속에서 아두이노를 어떻게 배울지, 간단한 튜토리얼을 진행하겠습니다!");
                NextFlow(1);
                break;

            case 3:
                SetTextBox("우선 아두이노와 모듈을 가볍게 조립해보겠습니다.");
                NextFlow(1);
                break;

            case 4:
                SetTextBox("모듈의 '조립'은 지금 눈 앞에 있는 '크래프트 테이블'을 통해 할 수 있습니다.");
                NextFlow(1);
                break;

            case 5:
                SetTextBox("하지만 그전에 우선! 어떻게 조립해야하는지를 알아야 겠지요?");
                NextFlow(1);
                break;

            case 6:
                SetTextBox("그 방법은 벽에 붙어 있는 칠판을 통해 확인 할 수 있습니다.");
                NextFlow(1);
                break;

            case 7:
                SetTextBox("W,A,S,D 버튼을 이용해 움직여 칠판을 향해 다가가 봅시다!");
                NextFlow(1);
                break;

            case 8:
                TextBoxActive(false);
                MovePointList[0].SetActive(true);
                OutTrigger = 1;
                break;

            case 9:
                TextBoxActive(true);
                SetTextBox("잘했습니다!");
                NextFlow(1);
                break;

            case 10:
                SetTextBox("지금쯤 아시겠지만 마우스를 움직여 화면을 회전할 수도 있습니다.");
                NextFlow(1);
                break;

            case 11:
                SetTextBox("만약 화면을 고정하고 싶으시다면 Art 버튼을 눌러 화면을 고정 시킬 수 있습니다.");
                NextFlow(1);
                break;

            case 12:
                SetTextBox("칠판에는 이렇게 UNO보드, 브레드보드, 그리고 사용될 모듈이 그려져 있습니다.");
                NextFlow(1);
                break;

            case 13:
                SetTextBox("마우스를 가져다 대면 각 모듈에 대한 설명을 볼 수 있으니 한번 시험해 보세요!");
                NextFlow(1);
                break;

            case 14:
                SetTextBox("자, 그럼 'Auto'버튼을 클릭해 모듈 교육을 시작해 봅시다!");
                NextFlow(1);
                break;

            case 15:
                TextBoxActive(false);
                OutTrigger = 2;
                break;

            case 16:
                TextBoxActive(true);
                SetTextBox("칠판에 자동으로 어떤 모듈의 어떤 부분을 어디에 연결해야하는지 표시되는 것을 볼 수 있습니다!");
                NextFlow(1);
                break;

            case 17:
                SetTextBox("자, 이제 실제로 조립을 하기 위해 원래 있었던 크래프트 테이블 쪽으로 다시 이동해봅시다.");
                NextFlow(1);
                break;

            case 18:
                TextBoxActive(false);
                MovePointList[1].SetActive(true);
                OutTrigger = 3;
                break;

            case 19:
                TextBoxActive(true);
                SetTextBox("크래프트 테이블의 조립버튼을 눌러 조립 화면으로 넘어가 봅시다!");
                NextFlow(1);
                break;

            case 20:
                TextBoxActive(false);
                OutTrigger = 4;
                break;

            case 21:
                TextBoxActive(true);
                SetTextBox("보다시피 처음에는 UNO보드, 브레드보드만 존재합니다.");
                NextFlow(1);
                break;

            case 22:
                SetTextBox("모듈 버튼을 클릭해봅시다.");
                NextFlow(1);
                break;

            case 23:
                TextBoxActive(false);
                OutTrigger = 5;
                break;

            case 24:
                TextBoxActive(true);
                SetTextBox("모듈 화면이 나왔습니다.");
                NextFlow(1);
                break;

            case 25:
                SetTextBox("이곳에서 사용할 모듈을 꺼낼 수 있습니다.");
                NextFlow(1);
                break;

            case 26:
                SetTextBox("이번에 사용할 '초음파 센서 - HC-SR04'를 하나 클릭해서 꺼내봅시다!");
                NextFlow(1);
                break;

            case 27:
                TextBoxActive(false);
                OutTrigger = 6;
                break;

            case 28:
                TextBoxActive(true);
                SetTextBox("잘했습니다!");
                NextFlow(1);
                break;

            case 29:
                SetTextBox("초음파센서가 테이블 위에 생성되었습니다.");
                NextFlow(1);
                break;

            case 30:
                SetTextBox("생성된 초음파 센서는 마우스 드래그를 통해 원하는 위치로 이동 할 수도 있고,");
                NextFlow(1);
                break;

            case 31:
                SetTextBox("슬라이더를 통해 회전시킬수도 있습니다!");
                NextFlow(1);
                break;

            case 32:
                SetTextBox("이제 모듈과 UNO보드를 연결해 보겠습니다.");
                NextFlow(1);
                break;

            case 33:
                SetTextBox("UNO보드의 5V를 클릭해봅시다.");
                NextFlow(1);
                break;

            case 34:
                SetTextBox("잘 안보인다면, 마우른 오른쪽 버튼 클릭으로 화면을 줌인해서 볼 수 있습니다.");
                NextFlow(1);
                break;

            case 35:
                TextBoxActive(false);
                OutTrigger = 7;
                break;

            case 36:
                TextBoxActive(true);
                SetTextBox("다음으로 초음파 모듈의 VCC핀을 클릭해봅시다.");
                if (doNotClick == false)
                    NextFlow(1);
                break;

            case 37:
                TextBoxActive(false);
                OutTrigger = 8;
                break;

            case 38:
                TextBoxActive(true);
                SetTextBox("자동으로 연결 선이 생성되는 것을 볼 수 있습니다!");
                if (doNotClick == false)
                    NextFlow(1);
                break;

            case 39:
                SetTextBox("정확히 연결 되었다면 완료버튼을 눌러봅시다!");
                NextFlow(1);
                break;


            //case 34:
            //    SetTextBox("잘 안보인다면, 마우른 오른쪽 버튼 클릭으로 화면을 줌인해서 볼 수 있습니다.");
            //    NextFlow(1);
            //    break;

            //case 35:
            //    SetTextBox("자동으로 연결 선이 생성되는 것을 볼 수 있습니다!");
            //    NextFlow(1);
            //    break;

            //case 36:
            //    SetTextBox("연결 되었다면 완료버튼을 눌러봅시다!");
            //    NextFlow(1);
            //    break;

            //case 37:
            //    TextBoxActive(false);
            //    OutTrigger = 7;
            //    break;

            //case 38:
            //    TextBoxActive(true);
            //    SetTextBox("제대로 칠판의 지시사항을 따랐다면 잘했다는 말과 함께 칠판에 다음 지시가 나왔을 겁니다.");
            //    NextFlow(1);
            //    break;

            //case 5:
            //    TextBoxActive(true);
            //    SetTextBox("잘했어요!");
            //    NextFlow(1);
            //    break;

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


    private void donotClickFalse()
    {
        doNotClick = false;
    }
}