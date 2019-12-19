using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    public int ControlMode = 1; // 0:레이캐스트 , 1.마우스
    public new GameObject camera;
    public RaycastHit hit;
    public Ray ray;

    [SerializeField]
    private GameObject Myobject;

    public Vector3 pointting;//위치를 가져옴

    [SerializeField]
    private GameObject NowArround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ControlMode == 1)
            return;

        Debug.DrawRay(camera.transform.position, camera.transform.forward * 400.0f, Color.red);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 400.0f))
        {
            Debug.Log(hit.collider.name);
            ArroundOnOff();
            ArduinoCtrl();
        }

    }

    private void ArduinoCtrl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (hit.collider.name)
            {
                case "BlockCordingButton":
                    hit.collider.gameObject.GetComponent<OnCubeClick>().OnMouseDown();
                    break;
            }

            if (hit.collider.tag == "Sensor")
            {
                Myobject = hit.collider.gameObject;
                Myobject.transform.parent = camera.transform;
            }

            if (hit.transform.tag == "Arround")
            {
                pointting = hit.transform.position;
                NowArround = hit.transform.gameObject;
                hit.collider.gameObject.GetComponent<MouseOverArround>().OnMouseDown();
            }

            if (hit.transform.tag == "Line")
            {
                try
                {
                    hit.transform.gameObject.GetComponent<StartLine>().OnMouseDown();
                }
                catch
                {
                    hit.transform.gameObject.GetComponent<End>().OnMouseDown();
                }
            }

            UIClcikCheck();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            try
            {
                Myobject.transform.parent = null;
            }
            catch
            {

            }
        }
    }

    private void UIClcikCheck()
    {
        if (!(hit.collider.gameObject.GetComponent<CreateAduinoSonic>() == null))
        {
            hit.collider.gameObject.GetComponent<CreateAduinoSonic>().ClickEvent();
        }

        if (!(hit.collider.gameObject.GetComponent<CreateAduinoTemp>() == null))
        {
            hit.collider.gameObject.GetComponent<CreateAduinoTemp>().ClickEvent();
        }

        if (!(hit.collider.gameObject.GetComponent<CreateAduinoIll>() == null))
        {
            hit.collider.gameObject.GetComponent<CreateAduinoIll>().ClickEvent();
        }
    }

    private void ArroundOnOff()
    {
        if (hit.collider != null)
        {
            if (NowArround != null)
            {
                if (hit.transform.gameObject != NowArround)
                {
                    NowArround.GetComponent<MouseOverArround>().OnMouseExit();
                }
            }

            if (hit.transform.tag == "Arround")
            {
                NowArround = hit.transform.gameObject;
                hit.collider.gameObject.GetComponent<MouseOverArround>().OnMouseEnter();
            }

        }
    }
}
