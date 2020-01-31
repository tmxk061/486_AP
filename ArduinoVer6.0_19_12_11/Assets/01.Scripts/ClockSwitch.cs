using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSwitch : MonoBehaviour
{
    public Clock clock;
    public SubSpin sp;

    public GameObject Pin;

    [SerializeField]
    Vector3 cvec;

    [SerializeField]
    float CSpeed;

    void Start()
    {
        clock.gameObject.GetComponent<Clock>().enabled = false;
    }


    void Update()
    {
        SubStart();
    }
 
    public void SubStart()
    {
        cvec = new Vector3(sp.vec.x, sp.vec.z, sp.vec.y);
        CSpeed = sp.lotateSpeed;

        if (sp.DigitalConnect == true && sp.GNDConnect == true && sp.VccConnect == true)
        {
            Pin.gameObject.transform.localRotation = Quaternion.Euler(cvec);
        }

    }

    public void CLockBlockStart()
    {
        if (sp.DigitalConnect == true && sp.GNDConnect == true && sp.VccConnect == true)
        {
            clock.gameObject.GetComponent<Clock>().enabled = true;
        }
    }
}