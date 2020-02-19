using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBtn : MonoBehaviour
{
    public string KEY;
    public string NAME;
    public string DATE;

    public GameObject Parent;

    public void OnBtnClick()
    {
        Modul_Save.instance.Load(KEY);
        Parent.SetActive(false);
    }

    public void NetWorkBtnOnClicik()
    {
        GameObject.Find("SaveMgr").GetComponent<NetworkSave>().OnNetworkSave(KEY, NAME, DATE);
    }

    public void DeleteBtnOnClicik()
    {
        Modul_Save.instance.DeleteModul(KEY);
        Parent.SetActive(false);
    }
}
