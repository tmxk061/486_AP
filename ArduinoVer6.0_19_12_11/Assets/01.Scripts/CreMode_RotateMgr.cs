using UnityEngine;
using UnityEngine.UI;

public class CreMode_RotateMgr : MonoBehaviour
{
    public Camera myCam;
    public GameObject RotateCtrl;

    public GameObject TargetSensor;

    public Slider X_Slider;
    public Slider Y_Slider;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.gameObject.tag == "Sensor")
                {
                    RotateCtrl.SetActive(true);
                    TargetSensor = hit.transform.gameObject;
                    RotateCtrl.transform.position = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
                }
            }
        }

        if (TargetSensor == null)
        {
            RotateCtrl.SetActive(false);
        }

        if (Input.GetMouseButton(1))
        {
            RotateCtrl.SetActive(false);
        }

        SlideKeyCtrl();
        SlideRotate();
    }

    private void SlideKeyCtrl()
    {
        if (TargetSensor == null)
            return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TargetSensor.transform.Rotate(45f, 0f, 0f);
            PosReset();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TargetSensor.transform.Rotate(0f, 0f, 45f);
            PosReset();
        }
    }

    private void SlideRotate()
    {
        if (TargetSensor == null)
            return;

        TargetSensor.transform.rotation = Quaternion.Euler(TargetSensor.transform.rotation.x + (X_Slider.value * 10 * 36),
                                                        TargetSensor.transform.rotation.y + (Y_Slider.value * 10 * 36),
                                                        TargetSensor.transform.rotation.z);
        PosReset();
    }

    private void PosReset()
    {
        if (TargetSensor.GetComponent<UltValue>() != null)
        {
            TargetSensor.GetComponent<UltValue>().linePosReset();
        }

        if (TargetSensor.GetComponent<TempHumiParent>() != null)
        {
            TargetSensor.GetComponent<TempHumiParent>().linePosReset();
        }

        if (TargetSensor.GetComponent<lightSensor>() != null)
        {
            TargetSensor.GetComponent<lightSensor>().linePosReset();
        }

        if (TargetSensor.GetComponent<ServoManager>() != null)
        {
            TargetSensor.GetComponent<ServoManager>().linePosReset();
        }

        if (TargetSensor.GetComponent<DC>() != null)
        {
            TargetSensor.GetComponent<DC>().linePosReset();
        }

        if (TargetSensor.GetComponent<SoundParent>() != null)
        {
            TargetSensor.GetComponent<SoundParent>().linePosReset();
        }

        if (TargetSensor.GetComponent<LEDManager>() != null)
        {
            TargetSensor.GetComponent<LEDManager>().linePosReset();
        }

        if (TargetSensor.GetComponent<WaterValue>() != null)
        {
            TargetSensor.GetComponent<WaterValue>().linePosReset();
        }
    }
}