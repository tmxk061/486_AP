using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCreateBlockBtn : MonoBehaviour
{
    public GameObject obj;

    public GameObject ParentObj;
    public GameObject Spwn;

    public void ClickBtnEvnet()
    {
        obj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));
        GameObject newobj = Instantiate(obj);
        newobj.transform.SetParent(ParentObj.transform);
        newobj.transform.position = Spwn.transform.position;
    }
}
