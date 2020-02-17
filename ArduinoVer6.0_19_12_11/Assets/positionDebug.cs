using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionDebug : MonoBehaviour
{
    void Start()
    {
        Debug.Log("스타트"+transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("갱신" + transform.position);
    }
}
