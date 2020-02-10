using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_EndPopup : MonoBehaviour
{
    public int trigerNumber;
    public bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        OnTutorialTriggerOn();
    }

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
