using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    // public GameObject Modules;
    // MouseOverArround[] Circuit;
    //public GameObject MakeLine;


    void OnTriggerEnter(Collider col)  // 휴지통에 선언해둔 물체들 닿았을 때 삭제하는 코드
    {
        if (col.gameObject.tag == "Sensor" || col.gameObject.tag == "BreadPin" || col.gameObject.tag == "resister" ||
          col.gameObject.tag == "OUTPUT" || col.gameObject.tag == "Temperature" || col.gameObject.tag == "INPUT")
        {
            if (col.GetComponent<LineArray>() == true)
            {
                col.GetComponent<LineArray>().AllClear();
                Destroy(col.gameObject);
            }
            else
                Destroy(col.gameObject);
        }
    }
}
