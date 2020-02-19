using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadKind_btn : MonoBehaviour
{
    public GameObject LocalUI;
    public GameObject ServerUI;


    public void OnKindBtnClick(int i)
    {
        if (i == 0)
        {
            LocalUI.SetActive(true);
            ServerUI.SetActive(false);

        }
        else
        {
            LocalUI.SetActive(false);
            ServerUI.SetActive(true);
        }
    }

}
