using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRoom2_LightControl : MonoBehaviour
{
    bool L;
    public GameObject[] light;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        L = true;
        light = GameObject.FindGameObjectsWithTag("SubRoom2_Light");

        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (L == true)
        {
            L = false;
            animator.SetBool("TurnOn", false);
            TurnOffLight();

            //Debug.Log("true");
        }
        else if (L == false)
        {
            L = true;
            animator.SetBool("TurnOn", true);
            TurnOnLight();

            //Debug.Log("false");
        }
    }

    void TurnOnLight()
    {
        //light.SetActive(true);
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(false);
        }
    }

    void TurnOffLight()
    {
        //light.SetActive(false);
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(true);
        }
    }
}
