using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBoard_Setting : MonoBehaviour
{
    [SerializeField]
    private MouseOverArround[] pin;

    // Start is called before the first frame update
    void Start()
    {
        pin = this.gameObject.transform.GetComponentsInChildren<MouseOverArround>();

        for (int i = 0; i < pin.Length; i++)
        {
            pin[i].Parents = this.gameObject;
        }
     
    }

  
}
