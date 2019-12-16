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

    private ControlArduino arduino;
    public int TimeForWait = 0;

    #endregion 변수

    protected override void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();

        base.Start();
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