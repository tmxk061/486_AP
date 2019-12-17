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

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        Debug.Log("start");
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        yield return new WaitForSeconds(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if(block != null)
            StartCoroutine(block.Run(0));

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
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



    public override IEnumerator GetCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
            GameManager.connectArduino.SetMeshMaterial(false);
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetSyncCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
            GameManager.connectArduino.SetMeshMaterial(false);
    }

    public override IEnumerator GetBtCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetBtCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
            GameManager.connectArduino.SetMeshMaterial(false);
    }
    #endregion 필수 구현 부분


}