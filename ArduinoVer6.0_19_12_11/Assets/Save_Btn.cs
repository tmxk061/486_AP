using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_Btn : MonoBehaviour
{
    public GameObject parent;
    public Text NameText;

    public void OnBtnClcik()
    {
        Modul_Save.instance.Save(NameText.text);
        NameText.text = "";
        parent.SetActive(false);
    }
}
