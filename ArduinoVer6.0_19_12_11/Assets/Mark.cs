using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{

    void OnTriggerEnter(Collider col)  
    {
        if (col.gameObject.tag == "Player")       
        {
            col.gameObject.SetActive(false);
        }
    }
}
