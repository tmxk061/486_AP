using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public bool get;
    public GameObject canvars;

    private void Start()
    {
        get = false;
        canvars.SetActive(false);
    }

    private void OnMouseDown()
    {
        get = true;
        Destroy(this.gameObject);
        canvars.SetActive(true);
    }
}
