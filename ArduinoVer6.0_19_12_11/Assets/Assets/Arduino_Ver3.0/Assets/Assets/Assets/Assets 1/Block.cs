using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Block : MonoBehaviour, IDragHandler, IDropHandler
{
    // Start is called before the first frame update
    #region 변수

    // 아두이노 모듈 이용하는 자식 블록에서 사용
    // private ControlArduino arduino;

    // 블록 구현부
    private GameObject UpObj = null;
    private GameObject DownObj;
    protected Collider2D[] colliders;
    protected Collider2D UpCollider;
    protected Collider2D DownCollider;
    protected GameObject ParentObj;
    private Block sample;
    
    //
    protected bool GetChild = false;
    #endregion


    #region 물리 구현 부분
    public void OnDrop(PointerEventData eventData)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.transform.parent != null)
        {
            if (UpObj != null)
            {
                Block block = BlockManager.instance.BlockIdentity(UpObj);
                block.SetDownColllider(true);
                UpCollider.isTrigger = true;

                this.transform.SetParent(ParentObj.transform);
            }
        }
        //var screenpoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);

        if (GameManager.RunBlock == true)
            transform.position = Input.mousePosition; //secondCamera.ScreenToWorldPoint(screenpoint);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "region")
        {
            if (collision == null)
                return;

            if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
            {
                if (this.tag != "Block") // StartBlock블록 제외
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


    #region 콜라이더
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

    // 유니티 작동
    public abstract IEnumerator Run(float s);
    public abstract IEnumerator SyncRun(bool s);

    // 아두이노 코드 작성
    public abstract IEnumerator GetCode(bool s);
    public abstract IEnumerator GetSyncCode(bool s);
    public abstract IEnumerator GetBtCode(bool s);
}