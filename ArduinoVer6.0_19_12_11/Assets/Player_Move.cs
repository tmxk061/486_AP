using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    public Slider heightSlider;
    public Slider velocitySlider;
    public Canvas canvas;
    
    

    public float playerHeight;
    public float rotateSpeed = 5f;

    public float cameraRotationLimit = 80f;

    private Vector3 rotation = Vector3.zero;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;

    // 카메라 회전 -> true = 불가, false = 가능
    private bool StopCamRotation = false;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        //cam.transform.position.y = new Vector3(transform.position.x, 130 + 70 * heightScroll.value, transform.position.z);

        //Vector3 swap = gameObject.transform.position;
        //swap.y = 130 + 70 * heightScroll.value;
        //gameObject.transform.position = swap;
        transform.position = new Vector3(transform.position.x, 130 + 70 * heightSlider.value, transform.position.z);
        //11= playerHeight;
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        rotation = new Vector3(0f, yRot, 0f) * rotateSpeed; //x
        cameraRotation = xRot * rotateSpeed; //y (카메라만 위로 돌아감)

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameManager.lux = 500;
        //    Debug.Log(GameManager.lux);
        //}
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (StopCamRotation == false)
            {
                StopCamRotation = true;
                canvas.gameObject.SetActive(true);
            }

            else
            {
                StopCamRotation = false;
                canvas.gameObject.SetActive(false);
            }
        }
        
    }

    void FixedUpdate() //Movement Rotation
    {

        if (GameManager.RunBlock == false)
        {
            Move();
            if (StopCamRotation != true)
                PreformRotation();
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
        float speed = 100 + 200 * velocitySlider.value;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime * -1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * -1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }
}
