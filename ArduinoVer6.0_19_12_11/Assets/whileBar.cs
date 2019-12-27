using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whileBar : Block
{
    [SerializeField]
    Text RepeatText;

    protected override void Start()
    {
        DownCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    public void ShowRepeatNum(int num)
    {
        if (!(num > 0))
            RepeatText.text = "반복";
        else
            RepeatText.text = num + "번 반복";
    }

    #region 유니티 오브젝트 작동 부분
    public override IEnumerator Run()
    {
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            yield return StartCoroutine(block.Run());
        }
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
    #endregion 유니티 오브젝트 작동 부분


    #region 아두이노 코드 출력
    public override void GetCode()
    {
        GameManager.loop.Add("}\n");

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            block.GetCode();
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }

    public override IEnumerator GetBtCode(bool s)
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }
    #endregion 아두이노 코드 출력
}
