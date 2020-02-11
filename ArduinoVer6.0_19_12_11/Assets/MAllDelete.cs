using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAllDelete : MonoBehaviour
{
    GameObject[] Sensor;

    public ConfirmSensor cs;

    public void FandDSensor()
    {
        Sensor = GameObject.FindGameObjectsWithTag("Sensor");

        try
        {
            for (int i = 0; i < Sensor.Length; i++)
            {
                Destroy(Sensor[i]);
            }
        }
        catch
        {

        }

        cs.DeleteAnser();
    }
}
