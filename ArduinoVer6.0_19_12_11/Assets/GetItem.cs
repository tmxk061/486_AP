using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public bool get;

    public GameObject canvas;

    private void Start()
    {
        get = false;
        canvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        get = true;
        Destroy(this.gameObject);
        canvas.SetActive(true);
    }
}
