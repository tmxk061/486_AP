using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaterBlock : Block
{
    [SerializeField]
    heaterSwitch heaterswitch;

    public override void RunDetail()
    {
        
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
