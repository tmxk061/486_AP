using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ifBar : Block
{
    #region 변수

    //private Vector3 mos, trans;
    //private Vector3 distance;
    //public Socket selectSocket;
    //private RectTransform rect;
    //private ifBlock block;
    

    public int TimeForWait = 0;
    
    #endregion 변수

    private void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>(); //아두이노 오브젝트 찾기
        ParentObj =
            GameObject.Find("PanelBlockCoding").
            gameObject.transform.Find("CodingPanel").
            gameObject.transform.Find("CodingMaskPanel"). //코딩마스크패널 찾기
            gameObject;

        this.transform.position = new Vector3(930, 421); //초기위치지정

        colliders = this.GetComponents<Collider2D>();//위, 아래 충돌 지정
        if (colliders != null)
        {
            DownCollider = colliders[0];

            UpCollider = colliders[1];
        }

        this.transform.SetParent(ParentObj.transform);
    }

    #region 필수 구현 부분
    public override IEnumerator Run(float s)
    {
        GetChild = false;
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.Run(0));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false) GameManager.RunbtnWork();
    }

    public override IEnumerator SyncRun(bool s)
    {
        yield return new WaitForSecondsRealtime(1f);
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.SyncRun(s));
            GetChild = true;
        }
    }


    public override IEnumerator GetCode(bool s)
    {
        GameManager.loop.Add("}\n");

        GetChild = false;
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode();
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");

        GetChild = false;
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");

        GetChild = false;
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(s));
            GetChild = true;
        }

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
        }
    }
    #endregion 필수 구현 부분
}