using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSavebtn : MonoBehaviour
{
    public GameObject parent;
    public Text NameText;

    public void OnBtnClcik()
    {
        BlockSave.instance.ClickSave(NameText.text);
        NameText.text = "";
        parent.SetActive(false);
    }
}
