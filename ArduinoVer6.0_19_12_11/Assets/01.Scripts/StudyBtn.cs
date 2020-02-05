using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudyBtn : MonoBehaviour
{
    public int ID;

    [SerializeField]
    private EducationMgr Edu_Mgr;

    //[SerializeField]
    //private GameObject MainView;

    [SerializeField]
    private GameObject MenuView;


    public void OnthisClick()
    {
        PlayerPrefs.SetInt("ID", ID);
        //SceneManager.LoadScene("Main_Stage")
        LoadingSceneManager.LoadScene("Main_Stage");

        //MainView.SetActive(true);

        //Edu_Mgr.Edu_ID = ID;
        //Edu_Mgr.setting();

        //MenuView.SetActive(false);
    }
}
