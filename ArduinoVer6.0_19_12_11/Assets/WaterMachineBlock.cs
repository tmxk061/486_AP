using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterMachineBlock : Block
{
    [SerializeField] water_machin WaterMachine;
    //[SerializeField] Dropdown MachineNum;
    [SerializeField] Dropdown MachineRun;

    float Distance = 15f;

    public override void RunDetail()
    {
        Debug.Log(WaterMachine.UltSensor.sqrLen);
        float aa = WaterMachine.UltSensor.sqrLen;
        if (aa <= Distance)
        {
            WaterMachine.CreateWater();
            WaterMachine.Used = true;
            //if (MachineRun.value == 0)
            //{
            //    WaterMachine.CreateWater();
            //}
        }
        else
        {
            WaterMachine.EndWater();
            WaterMachine.Used = false;
        }
        //else if (MachineRun.value == 1)
        //{
        //    WaterMachine.EndWater();
        //}
        //if (WaterMachine.UltSensor.offset.magnitude <= Distance)
        //{
        //    WaterMachine.CreateWater();
        //}
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
