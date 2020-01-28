using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToiletBlock : Block
{
    [SerializeField] usetoilet usetoilet;
    
    public override void RunDetail()
    {
        usetoilet.DownWater();
    }

    public override IEnumerator SyncRun(bool s)
    {
        throw new System.NotImplementedException();
    }

    // GetCode(), AddCode() 
    public override IEnumerator GetBtCode(bool s)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        throw new System.NotImplementedException();
    }
}
