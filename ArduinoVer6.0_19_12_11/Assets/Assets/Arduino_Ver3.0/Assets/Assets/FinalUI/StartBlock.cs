using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartBlock : Block
{
    #region 변수

    //private GameObject dragObject;
    //private RectTransform rect;
    //private Vector3 mos, trans;
    //private Vector3 distance;
    //private GameObject UpObj;
    //private bool First = true;

    #endregion 변수


    protected override void Start()
    {
        DownCollider = this.GetComponent<Collider2D>();
    }


    #region 유니티 오브젝트 작동 부분
    public override IEnumerator Run()
    {
        Debug.Log("start");

        yield return base.Run();
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GameManager.openArduino();

        GetChild = false;

        yield return new WaitForSecondsRealtime(1f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.SyncRun(s));

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }
    #endregion 유니티 오브젝트 작동 부분

    #region 아두이노 코드 출력
    public IEnumerator GetMergeCode()   // ConnectArduino.cs에서 버튼클릭시 호출
    {
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            block.GetCode();

        yield return new WaitForSeconds(0.3f);

        GameManager.MergeCode();    // 각 블록에서 얻은 코드 통합 후 클립보드 복사
    }


    public override IEnumerator GetSyncCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetSyncCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
        {

        }

    }

    public override IEnumerator GetBtCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetBtCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
        {

        }

    }
    #endregion 아두이노 코드 출력
    
}