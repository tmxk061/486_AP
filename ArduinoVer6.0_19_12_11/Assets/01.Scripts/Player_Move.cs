using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    public Camera cam;
    public Rigidbody rb;

    public GameObject Modules;
    
    public float rotateSpeed = 5f;

    public float cameraRotationLimit = 80f;

    private Vector3 rotation = Vector3.zero;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;

    // 카메라 회전 -> true = 불가, false = 가능
    public bool StopCamRotation = false;

    bool ClicRM;

    [SerializeField]
    private PlayerRaycast rayctrl;

    public GameObject Craft_table;
    public GameObject table_Point;

    private bool isAct = true;

    void Update()
    {
        if (isAct)
        {
            MouseCameraMove();

            PlayerPause();

            //MoveTable();

            MainCamZoomin();
        }
    }

    private void MainCamZoomin()
    {
        if (CraftTable_Mgr.instance.CreateMode == true)
            return;

        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = 20;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = 60;
        }
    }

    void FixedUpdate() //Movement Rotation
    {

        if (GameManager.RunBlock == false && CraftTable_Mgr.instance.CreateMode == false)
        {
            Move();
            if (StopCamRotation != true)
                PreformRotation();
        }
    }

    private void MouseCameraMove()
    {
        if (CraftTable_Mgr.instance.CreateMode == true)
            return;

        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        rotation = new Vector3(0f, yRot, 0f) * rotateSpeed; //x
        cameraRotation = xRot * rotateSpeed; //y (카메라만 위로 돌아감)
    }

    private void MoveTable()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CraftTable_Mgr.instance.CreateMode == true)
                return;
            //Craft_table.SetActive(false);
            Craft_table.transform.position = table_Point.transform.position;
            Craft_table.transform.rotation = table_Point.transform.rotation;
            //Craft_table.SetActive(true);
        }
    }

    public void PlayerPause()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (StopCamRotation == false)
            {
                //rayctrl.ControlMode = 1;
                guidHud_Mgr.instance.changeGuide(1);
                StopCamRotation = true;
            }
            else
            {
                guidHud_Mgr.instance.changeGuide(0);
                StopCamRotation = false;
            }

        }
    }

    private void PlayerRotate()
    {
        if (StopCamRotation == true)
        { 
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0, -30, 0) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
            }
        }
    }

    void PreformRotation() //X, Y회전
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
        }
    }

    private void Move()
    {
        if (!isAct)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 200 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, 200 * Time.deltaTime * -1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(200 * Time.deltaTime * -1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(200 * Time.deltaTime, 0, 0));
        }

        PlayerRotate();

    }

    public void ActSet(bool b)
    {
        isAct = b;
    }


   
}
