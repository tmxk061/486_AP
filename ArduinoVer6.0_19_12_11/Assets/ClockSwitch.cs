using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSwitch : MonoBehaviour
{

    public GameObject clock;
    public SubSpin sp;

    void Start()
    {
        clock.gameObject.GetComponent<Clock>().enabled = false;
    }

    void Update()
    {
        if (sp.DigitalConnect == true && sp.GNDConnect == true && sp.VccConnect == true)
        {
            clock.gameObject.GetComponent<Clock>().enabled = true;
        }
    }
}
