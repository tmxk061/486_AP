using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edu_Find_Slot : MonoBehaviour
{
    public int ModulNumber;
    private List<GameObject> EduSlots;

    // Start is called before the first frame update
    void Start()
    {
        EduSlots = GameObject.Find("Education").GetComponent<EducationMgr>().Used_Modul_Array;

        for (int i = 0; i< EduSlots.Count; i++)
        {
            if (EduSlots[i] == null)
                continue;

            if (ModulNumber == EduSlots[i].GetComponent<EduModul>().Modul_num)
            {
                if (EduSlots[i].GetComponent<EduModul>().RealModel == null)
                {
                    EduSlots[i].GetComponent<EduModul>().RealModel = this.gameObject;
                    return;
                }
            }
        }
    }

}
