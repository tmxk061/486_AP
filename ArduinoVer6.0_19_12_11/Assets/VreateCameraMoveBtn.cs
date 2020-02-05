using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VreateCameraMoveBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera;


    public void OnLeftBtnClick()
    {
        Camera.transform.Translate(-20, 0, 0);
    }

    public void OnRightBtnClick()
    {
        Camera.transform.Translate(20, 0, 0);
    }
}
