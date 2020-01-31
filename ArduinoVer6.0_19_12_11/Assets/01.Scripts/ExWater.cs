using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExWater : MonoBehaviour
{
    public WaterValue wv;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wv.value);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Sensor")
        {
            Debug.Log(wv.value);
        }

    }

}
