using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// WhileBlock1
public class whileBlock : Block, IDragHandler, IDropHandler
{
    [SerializeField]
    InputField InputField;  // (WhileBlock1 -> InputField) - 횟수 입력
    int InputNum;           // CheckInputNum() 호출될때 바뀜

    [SerializeField]
    whileBar UnderBar;    // (WhileBlock1 -> UnderBar)
    RectTransform UnderBarLocation;     // UnderBar 위치
    Vector2 UnderBar_OriginPosition;    // 처음 좌표

    [SerializeField]
    ifbarRegion region;

    protected override void Start()
    {
        UnderBarLocation = UnderBar.transform.GetComponent<RectTransform>();
        UnderBar_OriginPosition = UnderBarLocation.anchoredPosition;
        
        base.Start();
    }

    #region 고유 
    public void ChangeBar(float vec)
    {
        UnderBarLocation.anchoredPosition = new Vector2(UnderBar_OriginPosition.x,
                                                        UnderBar_OriginPosition.y + vec);
        // barlocation.offsetMin = new Vector2(firstTop.x, firstTop.y - vec);                                // Bottom
    }

    // Content Type - Integer Number 해도 마이너스( - )랑 0은 들어가서 넣음
    public void CheckInputNum()    // (WhileBlock1 -> InputField -> On Value Changed(String) -> 함수)
    {
        if (InputField.text == "" || InputField.text == "0")
        {
            InputField.text = "";
            return;
        }

        string str = InputField.text;
        int result = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (!(int.TryParse(str, out result)))
            {
                InputField.text = "";
                return;
            }
        }
        InputNum = int.Parse(InputField.text);
    }
    #endregion 고유


    #region 유니티 오브젝트 작동 부분
    public override IEnumerator Run()
    {
        RunDetail();

        // if내부 진행중 테두리 들어옴
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        this.GetComponentInChildren<whileBar>().GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        Debug.Log("while시작");

        // while 자식 블록 실행
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            if (InputNum > 0)
            {
                int i = 1;
                while (i <= InputNum)
                {
                    Debug.Log("while" + i + "번 반복");
                    UnderBar.ShowRepeatNum(i);
                    yield return StartCoroutine(RunNextBlock());
                    i++;
                }
            }
        }
        Debug.Log("while끝");
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        this.GetComponentInChildren<whileBar>().GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        yield return StartCoroutine(UnderBar.Run());
    }

    public override IEnumerator SyncRun(bool s)
    {
        yield return new WaitForSeconds(0.1f);
    }
    #endregion 유니티 오브젝트 작동 부분


    #region 아두이노 코드 출력
    public override void GetCode()
    {
        base.GetCode();

        UnderBar.GetCode();
    }

    public override void AddCode()
    {
        if (InputNum <= 0)
        {
        }
        else if (InputNum > 0)
        {
            GameManager.loop.Add("for (int i = 0; i < " + InputNum + "; i++)\n" + "{");
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        yield return new WaitForSeconds(0.1f);
    }

    public override IEnumerator GetBtCode(bool s)
    {
        yield return new WaitForSeconds(0.1f);
    }
    #endregion 아두이노 코드 출력
}
