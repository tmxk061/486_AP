﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternBlock : Block
{
    [SerializeField] MissionLight missionLight;
    [SerializeField] MissionLight missionlight;
    [SerializeField] Dropdown dropdown;

    public override void RunDetail()
    {
        if (dropdown.value == 0)
        {
            missionLight.lux();
            missionlight.lux();
        }
        else if (dropdown.value == 1)
        {
            missionlight.notlux();
            missionLight.notlux();
        }
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
