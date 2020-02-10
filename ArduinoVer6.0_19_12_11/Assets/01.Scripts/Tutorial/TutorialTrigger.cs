using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public int trigerNumber;
    public bool used = false;

    public void OnTutorialTriggerOn()
    {
        if (TutorialMgr.instance.isStart &&
            TutorialMgr.instance.OutTrigger == trigerNumber &&
            !used)
        {
            used = true;
            TutorialMgr.instance.FlowNum++;
        }
    }

   
}
