using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_btnToggle : MonoBehaviour
{
    [SerializeField]
    private Image nextTarget;
    [SerializeField]
    private Text nextText;

    [SerializeField]
    private Image thisTarget;
    [SerializeField]
    private Text thisText;


    public void OnClick()
    {
        nextTarget.enabled = true;
        nextText.enabled = true;

        thisTarget.enabled = false;
        thisText.enabled = false;
    }
}
