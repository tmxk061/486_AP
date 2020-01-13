using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayzoneRunBtn : MonoBehaviour
{
    public GameObject RunBtn;


    public void Onbtnclick()
    {
        RunBtn.GetComponent<RunButton>().OnMouseDown();
    }
}
