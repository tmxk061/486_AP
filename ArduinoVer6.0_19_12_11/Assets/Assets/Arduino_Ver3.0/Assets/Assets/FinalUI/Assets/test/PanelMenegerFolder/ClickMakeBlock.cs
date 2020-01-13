using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMakeBlock : MonoBehaviour
{
    public GameObject obj;
    public GameObject parent;
    public GameObject Spwn;

    public void ClickEvent()
    {
        obj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));
        GameObject newobj = Instantiate(obj);
        newobj.transform.SetParent(parent.transform);
        newobj.transform.position = Spwn.transform.position;

        newobj.transform.localScale = GameObject.Find("StartBlock").GetComponent<RectTransform>().localScale;

        //obj.transform.position = new Vector3(0, 0);
        //obj.transform.localPosition = new Vector2(0, 0);
    }
}
