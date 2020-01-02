using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linetest : MonoBehaviour
{
    LineRenderer lr;
    Vector3 cube1Pos, cube2Pos;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 20f;
        lr.endWidth = 20f;

        cube1Pos = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        lr.SetPosition(0, GameObject.Find("c").GetComponent<Transform>().position);
        lr.SetPosition(1, GameObject.Find("b").GetComponent<Transform>().position);
    }

}
