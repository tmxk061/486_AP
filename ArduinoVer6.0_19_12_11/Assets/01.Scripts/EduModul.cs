using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EduModul : MonoBehaviour
{
    public GameObject RealModel;
    public GameObject RealCheck;
    public int Modul_num;
    public List<Transform> PinList;
    public GameObject Tooltip;

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

    public void OnMouseEnter()
    {
        Debug.Log("들어옴");
        Tooltip.SetActive(true);
    }

    public void OnMouseExit()
    {
        Tooltip.SetActive(false);
    }
}
