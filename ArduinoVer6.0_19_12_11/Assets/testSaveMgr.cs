using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSaveMgr : MonoBehaviour
{
    public GameObject parent;
    public GameObject target;

    public GameObject ParentObj;
    public GameObject Spwn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ES3.Save<GameObject>("target", target);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject loaobj = ES3.Load<GameObject>("target");

            GameObject newobj = Instantiate(loaobj);


            //obj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));
            newobj.transform.SetParent(ParentObj.transform);
            newobj.transform.position = Spwn.transform.position;

            //newobj.transform.localScale = GameObject.Find("StartBlock").GetComponent<RectTransform>().localScale;
        }
    }
}
