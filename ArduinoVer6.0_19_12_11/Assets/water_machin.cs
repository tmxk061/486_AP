using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_machin : MonoBehaviour
{
    [SerializeField]
    private GameObject water;


    public void CreateWater()
    {
        water.SetActive(true);
        Invoke("EndWater", 2f);
        
    }

    private void EndWater()
    {
        water.SetActive(false);
    }


}
