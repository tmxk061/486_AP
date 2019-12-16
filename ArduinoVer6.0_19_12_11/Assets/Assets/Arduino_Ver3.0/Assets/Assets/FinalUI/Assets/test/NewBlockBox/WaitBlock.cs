using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaitBlock : Block
{
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

    public int TimeForWait = 0;
    
    #endregion 변수
    
    // public void Start()

    #region 필수 구현부분
    public override IEnumerator Run(float s)
    {
        Debug.Log("웨이트 개시");
        GetChild = false;
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(TimeForWait);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.Run(0));
            GetChild = true;
        }

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        if (GetChild == false && s == 0)
        {
            GameManager.RunbtnWork();
        }
    } //실행

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        yield return new WaitForSecondsRealtime(TimeForWait + 1f);

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


    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;

        GameManager.loop.Add("delay(" + TimeForWait * 1000 + ");\n");

        yield return new WaitForSeconds(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    } //코드 떼오기

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
    

    #region 고유 구현 부분

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