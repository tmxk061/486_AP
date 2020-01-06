using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_machin : MonoBehaviour
{
    [SerializeField]
    private GameObject water;

    public UltValue UltSensor;


    public void CreateWater()
    {
        water.SetActive(true);     
    }

    public void EndWater()
    {
        water.SetActive(false);
    }


}
