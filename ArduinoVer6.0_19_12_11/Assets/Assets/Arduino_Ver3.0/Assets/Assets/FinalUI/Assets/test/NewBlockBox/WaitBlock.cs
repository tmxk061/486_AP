using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// ControlBlock1
public class WaitBlock : Block
{
    [SerializeField]
    InputField InputField;  // (ControlBlock1 -> InputField) - 시간 입력
    int InputNum;           // CheckInputNum() 호출될때 바뀜

    #region 변수
    //public int selectnum = 0;
    //[SerializeField]
    //public Canvas canvas;
    //public bool selectRun = true;
    //public bool UpConncet = false;
    //public bool DownConnect = false;
    //[SerializeField]
    //public Camera secondCamera;
    //private WaitForSeconds waitForSeconds;

    public int TimeForWait = 0; //안씀
    #endregion 변수

    // public void Start()

    // Content Type - Integer Number 해도 마이너스( - )랑 0은 들어가서 넣음
    public void CheckInputNum()    // (WhileBlock1 -> InputField -> On Value Changed -> 함수)
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

    #region 유니티 오브젝트 작동 부분
    public override IEnumerator Run()
    {
        Debug.Log("웨이트 개시");
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        // X초 대기
        yield return new WaitForSeconds(InputNum);
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            yield return StartCoroutine(block.Run());
        }
    } //실행

    public override void RunDetail()
    {

    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        yield return new WaitForSecondsRealtime(InputNum + 1f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.SyncRun(s));
            GetChild = true;
        }

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        if (GetChild == false && s == true)
        {
            GameManager.closeArduino();
            GameManager.SyncRun();
        }
    }
    #endregion 유니티 오브젝트 작동 부분


    #region 아두이노 코드 출력
    public override void GetCode()
    {
        
        base.GetCode();
    }

    public override void AddCode()
    {
        GameManager.loop.Add("delay(" + InputNum * 1000 + ");");
    }


    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;
      
        yield return new WaitForSeconds(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;
       
        yield return new WaitForSeconds(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncBTMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }
    #endregion 필수 구현부분
    

    #region 안쓰는듯

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(TimeForWait);
    } //몇초 대기
    
    public void setSecond(int i)
    {
        TimeForWait = i;
    }

    #endregion 고유 구현 부분
}