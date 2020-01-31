using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_machin : MonoBehaviour
{
    [SerializeField]
    private GameObject water;

    public UltValue UltSensor;

    public bool Used;

    public void CreateWater()
    {
        if (Used == false)
        {
            water.SetActive(true);
            Invoke("EndWater", 2f);
        }
    }

    public void EndWater()
    {
        water.SetActive(false);
    }


}
