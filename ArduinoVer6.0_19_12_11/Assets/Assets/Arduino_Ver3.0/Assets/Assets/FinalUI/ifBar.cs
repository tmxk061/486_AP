using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ifBar : Block, IDragHandler
{
    #region 변수

    //private Vector3 mos, trans;
    //private Vector3 distance;
    //public Socket selectSecket;
    //private RectTransform rect;
    //private ifBlock block;

    private GameObject UpObj;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;

    [SerializeField]
    private Collider2D DownCollider;

    [SerializeField]
    public Canvas canvas;

    private Block sample;
    public bool GetChild = false;

    #endregion 변수

    private void Start()
    {
        DownCollider = this.gameObject.GetComponent<BoxCollider2D>();
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

    public override void SetDownColllider(bool s)
    {
        if (DownCollider != null)
            DownCollider.isTrigger = s;
    }

    public override void SetUPColllider(bool s)
    {
        //코드 추가 바랍니다.

        //안씀q
    }

    public override bool CheckUoCollider()
    {
        return false;
    }

    public override bool CheckDownCollider()
    {
        return DownCollider.isTrigger;
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

    public override GameObject CheckParentObj()
    {
        return null;
    }

    #endregion 필수 구현 부분

    #region 물리 구현 부분

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "region")
        {
            if (collision == null)
                return;

            if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
            {
                if (UpCollider.isTrigger == true)
                {
                    sample = BlockManager.instance.BlockIdentity(collision);
                    if (sample != null)
                    {
                        if (sample.CheckDownCollider() == true)
                        {
                            transform.position = collision.transform.position + new Vector3(0, -51, 0);
                            this.transform.SetParent(sample.transform);
                            this.transform.SetAsFirstSibling();
                            UpObj = collision.gameObject;
                            UpCollider.isTrigger = false;
                            sample.SetDownColllider(false);
                        }
                    }
                }
            }
            else if (transform.position.y > collision.transform.position.y) // 자기 아랫부분에서 충돌할때
            {
                sample = BlockManager.instance.BlockIdentity(collision);
                if (sample != null)
                {
                    if (sample.CheckParentObj() == this.gameObject)
                    {
                        DownObj = collision.gameObject;
                    }
                }
            }
        }
    }

    #endregion 물리 구현 부분
}