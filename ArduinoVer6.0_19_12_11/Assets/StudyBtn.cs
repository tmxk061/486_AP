using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyBtn : MonoBehaviour
{
    public int ID;

    [SerializeField]
    private EducationMgr Edu_Mgr;

    [SerializeField]
    private GameObject MainView;

    [SerializeField]
    private GameObject MenuView;


    public void OnthisClick()
    {
        MainView.SetActive(true);

        Edu_Mgr.Edu_ID = ID;
        Edu_Mgr.setting();

        MenuView.SetActive(false);
    }
}
