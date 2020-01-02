using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Ctrl + M + O 클릭시 모든 Region 최소화됨 

public abstract class Block : MonoBehaviour, IDragHandler, IDropHandler
{
    // Start is called before the first frame update
    #region 변수

    // 아두이노 모듈 이용하는 자식 블록에서 사용
    // private ControlArduino arduino;

    // 블록 구현부
    protected GameObject UpObj = null;
    protected GameObject DownObj;
    protected Collider2D[] colliders;
    protected Collider2D UpCollider;
    protected Collider2D DownCollider;
    protected GameObject ParentObj;
    protected Block sample;

    //
    protected bool GetChild = false;
    #endregion

    protected virtual void Start()
    {
        //arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
        //selectSocket = arduino.PinList[0];
        //selectSocket2 = arduino.PinList[0];

        ParentObj = GameObject.Find("PanelBlockCoding").gameObject.transform.Find("CodingPanel").gameObject.transform.Find("CodingMaskPanel").gameObject;
        colliders = this.GetComponents<Collider2D>();

        this.transform.position = new Vector3(930, 421);

        if (colliders != null)
        {
            DownCollider = colliders[0];

            UpCollider = colliders[1];
        }
    }
    // 자식 블록에서 쓰는 Start() 예시
    //protected override void Start()
    //{
    //    arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
    //    selectSocket = arduino.PinList[0];
    //    selectSocket2 = arduino.PinList[0];

    //    base.Start();
    //}

    
    #region 물리 구현 부분
    public void OnDrop(PointerEventData eventData)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        if (this.tag == "ifBlock")
        {
            this.GetComponentInChildren<ifBar>().GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        }
        else if (this.tag == "whileBlock")
        {
            this.GetComponentInChildren<whileBar>().GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject thisblock = gameObject;

        if (thisblock.tag == "ifBar")
            thisblock = thisblock.GetComponentInParent<ifBlock>().gameObject;
        else if (thisblock.tag == "whileBar")
            thisblock = thisblock.GetComponentInParent<whileBlock>().gameObject;

        if (thisblock.transform.parent != null)
        {
            if (UpObj != null)
            {
                Block block = BlockManager.instance.BlockIdentity(UpObj);
                block.SetDownColllider(true);
                UpCollider.isTrigger = true;

                thisblock.transform.SetParent(ParentObj.transform);
            }
        }
        //var screenpoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);

        if (GameManager.RunBlock == true)
        {
            thisblock.transform.position = Input.mousePosition; //secondCamera.ScreenToWorldPoint(screenpoint);

            thisblock.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
            if (thisblock.tag == "ifBlock")
            {
                thisblock.GetComponentInChildren<ifBar>().GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
            }
            else if (thisblock.tag == "whileBlock")
            {
                thisblock.GetComponentInChildren<whileBar>().GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "region")
        {
            if (collision == null)
                return;

            if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
            {
                if (this.tag != "Block" && this.tag != "ifBar" && this.tag != "whileBar") // StartBlock블록 제외
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
    } //충돌시 붙히기 코드
    #endregion 물리 구현 부분


    #region 블록코딩 콜라이더
    public GameObject CheckParentObj()
    {
        return UpObj;
    } //위에 있는 블록 리턴


    public void SetUpColllider(bool s)
    {
        if (UpCollider != null)
        {
            UpCollider.isTrigger = s;
        }
    } //업 콜라이더 트리거 설정

    public void SetDownColllider(bool s)
    {
        if (DownCollider != null)
        {
            DownCollider.isTrigger = s;
        }
    } //업 콜라이더 트리거 설정

    
    public bool CheckUpCollider()
    {
        return UpCollider.isTrigger;
    } //위 충돌 트리거상태 리턴

    public bool CheckDownCollider()
    {
        return DownCollider.isTrigger;
    } //아래 충돌 트리거 상태 리턴
    #endregion 블록코딩 콜라이더


    #region 유니티 오브젝트 작동 부분
    public IEnumerator BlockOutline()
    {
        // 블록 지나갈때 테두리 깜박거리기
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    public virtual IEnumerator Run()
    {
        // 블록별로 달라지는것
        RunDetail();
        // RunDetail만 바꿔도 대부분되는데 if while wait등은 Run 수정

        yield return StartCoroutine(BlockOutline());

        // 자식 블록 실행
        yield return StartCoroutine(RunNextBlock());
    }

    public virtual void RunDetail()
    {
        
    }

    public virtual IEnumerator RunNextBlock()
    {
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            yield return StartCoroutine(block.Run());
        }
    }


    public abstract IEnumerator SyncRun(bool s);
    #endregion 유니티 오브젝트 작동 부분

    #region 아두이노 코드 출력
    public virtual void GetCode()
    {
        AddCode();
        
        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            block.GetCode();
        }
    } //코드 떼오기

    public virtual void AddCode()
    {

    }

    public abstract IEnumerator GetSyncCode(bool s);
    public abstract IEnumerator GetBtCode(bool s);
    #endregion 아두이노 코드 출력
}