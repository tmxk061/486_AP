using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// ifBlock
public class ifBlock : Block, IDragHandler, IDropHandler
{
    #region 변수

    //private GameObject dragObject;
    //private RectTransform rect;
    //private Vector3 mos, trans;
    //private Vector3 distance;
    //public Socket selectSocket;
    //[SerializeField]
    //public Canvas canvas;
    //public bool selectRun = true;
    // public RectTransform barrect;
    //public Vector3 Firstlocation;
    private GameObject dragObject;
    private RectTransform rect;
    Vector3 mos, trans;
    Vector3 distance;

    public int ThirdSel = 0;
    private bool okvalue = false;
    public int FirstSel = 0;
    public int SecondSel = 0;

    public ifBar UnderBar;

    public RectTransform barrect;
    public RectTransform barlocation;
    public ifbarRegion region;
    public Vector2 FirstAnchoredPosition;
    #endregion 변수

    protected override void Start()
    {
        //UnderBar
        UnderBar = this.gameObject.GetComponentInChildren<ifBar>();
        barlocation = UnderBar.transform.GetComponent<RectTransform>();
        FirstAnchoredPosition = barlocation.anchoredPosition;
        
        base.Start();
    }

    #region 유니티 오브젝트 작동 부분
    public override IEnumerator Run()
    {
        RunDetail();

        // if내부 진행중 테두리 들어옴
        //this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        //UnderBar.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        // if 자식 블록 실행
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            if (okvalue == true)
            {
                yield return StartCoroutine(RunNextBlock());
            }
            else
            {
                //yield return StartCoroutine(ElseBar.Run());
            }
        }

        // if내부 끝나면 테두리X
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        UnderBar.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        // if 이후 블록실행
        yield return StartCoroutine(UnderBar.Run());
    }

    public override void RunDetail()
    {
        okvalue = false;

        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                if (GameManager.distance >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.distance == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.distance <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 1)
        {
            if (SecondSel == 0)
            {
                if (GameManager.temp >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.temp == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.temp <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 2)
        {
            if (SecondSel == 0)
            {
                if (GameManager.humi >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.humi == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.humi <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 3)
        {
            if (SecondSel == 0)
            {
                if (GameManager.lux >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.lux == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.lux <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 4)
        {
            if (SecondSel == 0)
            {
                if (GameManager.water >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.water == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.water <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        Block block = null;

        okvalue = false;

        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                if (GameManager.distance >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.distance == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.distance <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 1)
        {
            if (SecondSel == 0)
            {
                if (GameManager.temp >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.temp == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.temp <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 2)
        {
            if (SecondSel == 0)
            {
                if (GameManager.humi >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.humi == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.humi <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 3)
        {
            if (SecondSel == 0)
            {
                if (GameManager.lux >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.lux == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.lux <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 4)
        {
            if (SecondSel == 0)
            {
                if (GameManager.water >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.water == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.water <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }

        if (okvalue == true)
        {
            GameManager.DigitalWrite(FirstSel.ToString() + SecondSel.ToString() + ThirdSel.ToString());
            block = BlockManager.instance.BlockIdentity(transform);
            if (block != null)
            {
                StartCoroutine(block.SyncRun(s));
                GetChild = true;
            }

            yield return new WaitForSecondsRealtime(region.count * 1f);
        }
        else if (okvalue == false)
        {
            yield return new WaitForSecondsRealtime(1f);
        }

        StartCoroutine(UnderBar.SyncRun(s));
    }
    #endregion 유니티 오브젝트 작동 부분

    #region 아두이노 코드 출력
    public override void AddCode()
    {
        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(distance>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(distance==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(distance<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 1)
        {
            GameManager.AddValueLis("int temp=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(temp>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(temp==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(temp<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 2)
        {
            GameManager.AddValueLis("int humi=0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(humi>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(humi==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(humi<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 3)
        {
            GameManager.AddValueLis("int lux=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux >=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux ==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux <=" + ThirdSel + ")\n" + "{");
            }
        }
    }

    public override void GetCode()
    {
        base.GetCode();

        UnderBar.GetCode();
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;

        Block block = null;

        GameManager.loop.Add("if(sync==" + '"' + FirstSel.ToString() + SecondSel.ToString() + ThirdSel.ToString() + '"' + ")\n{");

        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(distance>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(distance==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(distance<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 1)
        {
            GameManager.AddValueLis("int temp=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(temp>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(temp==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(temp<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 2)
        {
            GameManager.AddValueLis("int humi=0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(humi>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(humi==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(humi<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 3)
        {
            GameManager.AddValueLis("int lux=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux >=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux ==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux <=" + ThirdSel + ")\n" + "{");
            }
        }

        block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(false));
            GetChild = true;
        }

        yield return new WaitForSeconds(region.count * 1f + 1f);

        StartCoroutine(UnderBar.GetSyncCode(s));
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;

        Block block = null;

        GameManager.loop.Add("if(sync==" + '"' + FirstSel.ToString() + SecondSel.ToString() + ThirdSel.ToString() + '"' + ")\n{");

        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(distance>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(distance==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(distance<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 1)
        {
            GameManager.AddValueLis("int temp=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(temp>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(temp==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(temp<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 2)
        {
            GameManager.AddValueLis("int humi=0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(humi>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(humi==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(humi<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 3)
        {
            GameManager.AddValueLis("int lux=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux >=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux ==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux <=" + ThirdSel + ")\n" + "{");
            }
        }

        block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(false));
            GetChild = true;
        }

        yield return new WaitForSeconds(region.count * 1f + 1f);

        StartCoroutine(UnderBar.GetBtCode(s));
    }
    #endregion 아두이노 코드 출력


    #region 고유 구현 부분

    public void ChangeBar(float vec)
    {
        barlocation.anchoredPosition = new Vector2(FirstAnchoredPosition.x, FirstAnchoredPosition.y + vec);

        // barlocation.offsetMin = new Vector2(firstTop.x, firstTop.y - vec);                                // Bottom
    }
  
    #endregion 고유 구현 부분
}