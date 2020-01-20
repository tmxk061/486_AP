using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSave : MonoBehaviour
{
    public void SaveBlock()
    {
        GameObject BlockCoding = GameObject.FindWithTag("Block");
        ES3.Save<GameObject>("aaa", BlockCoding);
    }

    public void LoadBlock()
    {
        GameObject BlockCoding = GameObject.FindWithTag("Block");
        ES3.Load<GameObject>("aaa");
        //BlockCoding = ES3.Load<GameObject>("aaa");
    }
}
