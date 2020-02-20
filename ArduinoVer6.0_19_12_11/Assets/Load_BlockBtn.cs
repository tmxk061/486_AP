using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_BlockBtn : MonoBehaviour
{
    public string NAME;
    public string DATE;

    public GameObject Parent;

    public void OnBtnClick()
    {
        BlockSave.instance.ClickLoad(NAME);
        Parent.SetActive(false);
    }

    public void NetWorkBtnOnClicik()
    {
        GameObject.Find("SaveMgr").GetComponent<NetworkSave>().OnNetworkBlockSave(NAME, DATE);
    }

    public void DeleteBtnOnClicik()
    {
        BlockSave.instance.DeleteBlockFile(NAME);
        Parent.SetActive(false);
    }
}
