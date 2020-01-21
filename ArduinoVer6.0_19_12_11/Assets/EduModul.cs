using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduModul : MonoBehaviour
{
    public GameObject RealModel;
    public GameObject RealCheck;
    public int Modul_num;
    public List<Transform> PinList;


    private void Update()
    {
        try
        {
            if (RealModel != null)
            {
                RealCheck.SetActive(true);
            }
            else
            {
                RealCheck.SetActive(false);
            }
        }
        catch
        {

        }        
    }
}
