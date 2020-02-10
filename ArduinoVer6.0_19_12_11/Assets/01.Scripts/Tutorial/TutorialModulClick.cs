using System.Collections;
using UnityEngine;



public class TutorialModulClick : MonoBehaviour
{
    public int trigerNumber;
    public bool used = false;

    public void OnMouseDown()
    {
        if (TutorialMgr.instance.isStart &&
           TutorialMgr.instance.OutTrigger == trigerNumber &&
           !used)
        {
            used = true;
            TutorialMgr.instance.doNotClick = true;
            TutorialMgr.instance.FlowNum++;
        }
    }

    
}