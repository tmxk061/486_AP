using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundParent : MonoBehaviour
{
    /* 아두이노 보드 용 연결
    private bool SoundPlus = false;
    private bool SoundMin = false;
    private bool SoundDig = false;
    private int SoundVccPower = 0;
    */

    public bool GNDConnect;
    public bool VCCConnect;
    public bool DigitalConnect;

    public float Data { get; set; }

    AudioSource audioSource;

    public GameObject Parent;
    float distance = 10;
    public bool MouseClick = false;
    private bool notMoveCheck = false; //안움직이는 드래그용 꼼수 변수(회전시 라인 따라가기용)
    public void linePosReset() //가지고 있는 라인들의 위치를 내 위치로 리셋(사기치는코드)
    {
        notMoveCheck = true;
        OnMouseDrag();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    #region MouseDrag

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position.z - Camera.main.transform.position.z);
        //Debug.Log(Camera.main.transform.position.z - this.transform.position.z );

        //if ((this.transform.position.z - Camera.main.transform.position.z) > 0)
        //distance = this.transform.position.z - Camera.main.transform.position.z;
        if (CraftTable_Mgr.instance.CreateMode == true)
            distance = Vector3.Distance(this.transform.position, GameObject.Find("CreateCamera").transform.position);
        else
            distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        // else
        //distance = Camera.main.transform.position.z - this.transform.position.z;
    }

    private void OnMouseUp()
    {
        MouseClick = false;
    }

    private void OnMouseDrag()
    {
        MouseClick = true;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance -= 10;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance += 10;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Sensor"))
        {
            if (notMoveCheck == true)
            {
                notMoveCheck = false;
                return;
            }
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
                                                Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;

            //Vector3 mousePosition = new Vector3(Input.mousePosition.x,
            //Input.mousePosition.y, distance);
            //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.position = objPosition;
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}
    }

    #endregion MouseDrag


    public void Run()
    {
        if (GNDConnect == true && VCCConnect == true && DigitalConnect==true)
        {
            audioSource.Play();
        }
    }
    public void Pause()
    {
        audioSource.Pause();
    }
}
