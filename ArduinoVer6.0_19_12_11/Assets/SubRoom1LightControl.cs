using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRoom1LightControl : MonoBehaviour
{
    bool L;
    public GameObject[] light;

    // public GameObject mlight;

    public IllValue lv;

    //LightObject lo;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        L = false;
      
        light = GameObject.FindGameObjectsWithTag("SubRoom1_Light");

        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(false);
        }       
    }

    private void OnMouseDown()
    {

      if (L == false)
      {
         if (lv.VccConnect == true && lv.GNDConnect == true && lv.AnalogConnect == true)
         {
             L = true;
             animator.SetBool("TurnOn", true);
             TurnOnLight();
         }     
       //Debug.Log("true");
      }
      else if (L == true)
      {
          L = false;
          animator.SetBool("TurnOn", false);
          TurnOffLight();

          //Debug.Log("false");
      }
 

    }

    void TurnOnLight()
    {
       for (int i = 0; i < light.Length; i++)
       {
           light[i].SetActive(true);
       }
    }

    void TurnOffLight()
    {
        
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(false);
        }
    }
}
