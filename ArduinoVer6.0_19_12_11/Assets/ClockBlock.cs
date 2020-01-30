using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBlock : Block
{
    [SerializeField] ClockSwitch clockSwitch;

    public override void RunDetail()
    {
        clockSwitch.CLockBlockStart();
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
