using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfGetItem : MonoBehaviour
{
    public GetItem gs;
    public GameObject pin1;

    void Start()
    {
        pin1.SetActive(false);
    }

    void Update()
    {
        useOn();
    }

    void useOn()
    {
        if (gs.get == true)
        {
            pin1.SetActive(true);
        }
    }
}
