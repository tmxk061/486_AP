using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossitionLimite : MonoBehaviour
{
    public GameObject Desk;
    public GameObject Modules;

     private void Start()
    {
        Desk = GameObject.Find("TrickTable");   
    
    }


    private void Update()
    {
        ArduinoRePosition();
    }

    void ArduinoRePosition()
    {
        Vector3 DP = Desk.gameObject.transform.position;
        Vector3 MP = Modules.gameObject.transform.position;

        float dis1 = Vector3.Distance(DP, MP);
        //float dis2 = Vector3.Distance(MP, DP);

        if (105 < dis1 )
        {
            Debug.Log(dis1);
            Modules.gameObject.transform.position = new Vector3(30, 125, 70);
        }
    }
}
