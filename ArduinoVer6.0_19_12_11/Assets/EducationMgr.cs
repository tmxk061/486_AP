using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationMgr : MonoBehaviour
{
 
    [SerializeField]
    private Transform Lines; // 모든라인을 담을 부모 오브젝트

    [SerializeField]
    private GameObject Line2D; //라인 오브젝트


    [SerializeField]
    private List<Transform> ArduinoPoint; //아두이노 위치목록

    [SerializeField]
    private List<Transform> BreadBoardPoint; //빵판 위치목록

    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject newLine = Instantiate(Line2D);
            newLine.transform.parent = Lines;

            LineMgr2D lineMgr = newLine.GetComponent<LineMgr2D>();

            lineMgr.Point1Set(ArduinoPoint[14].position);
            lineMgr.Point2Set(BreadBoardPoint[320].position);
            //lineMgr.ColorSet(255, 0, 0);
            lineMgr.UpdateLine();

        }
    }
}
