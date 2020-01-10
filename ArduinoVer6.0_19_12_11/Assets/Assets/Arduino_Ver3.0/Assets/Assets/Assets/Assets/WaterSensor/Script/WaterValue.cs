using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterValue : MonoBehaviour
{
    public bool VccConnect = false;
    public bool GNDConnect = false;
    public bool AnalogConnect = false;

    public GameObject Waterobject;
    public bool RunOn = false;
    float distance = 10;
    public bool MouseClick = false;
    public int value = 0;
    [SerializeField]
    //public WaterDetect[] Waterdetect;
    public WaterDetect[] Waterdetect;
    // Start is called before the first frame update
    void Start()
    {
        Waterobject = GameObject.Find("WaterObject");
    }

    #region MouseDrag

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position.z - Camera.main.transform.position.z);
        //Debug.Log(Camera.main.transform.position.z - this.transform.position.z );

        //if ((this.transform.position.z - Camera.main.transform.position.z) > 0)
        //distance = this.transform.position.z - Camera.main.transform.position.z;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        RunOn = true;

        StartCoroutine(Work());

    }

    public void Read()
    {
        RunOn = true;

        StartCoroutine(Work());


    }

    IEnumerator Work()
    {
        if (GNDConnect == true && AnalogConnect == true && VccConnect == true)
        {
            for (int i = 0; i < Waterdetect.Length; i++)
            {
                value += Waterdetect[i].value;
            }
            Debug.Log(value);
            value = 0;
        }

        yield return new WaitForSecondsRealtime(1.5f);

    }

    public void Pause()
    {
        RunOn = false;
    }
}
