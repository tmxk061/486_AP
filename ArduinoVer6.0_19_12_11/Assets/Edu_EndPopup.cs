using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edu_EndPopup : MonoBehaviour
{
    public GameObject Popup;
    public GameObject Menu;
    public GameObject Main;

    public void OnMenuBtn()
    {
        Menu.SetActive(true);
        Popup.SetActive(false);
        Main.SetActive(false);
    }

    public void OnRestartBtn()
    {
        Popup.SetActive(false);
    }
}
