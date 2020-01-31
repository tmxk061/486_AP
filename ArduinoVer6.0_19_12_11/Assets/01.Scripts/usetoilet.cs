using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usetoilet : MonoBehaviour
{
    Animator animator;
     bool use;

    public WaterValue wv;

    [SerializeField]
    float dely = -2f;

    [SerializeField]
    float mdely = 3f;


    void Start()
    {
        use = true;

        animator = GetComponent<Animator>();

        animator.SetBool("TurnOn", true);
       
    }

    private void Update()
    {
        dely -= Time.deltaTime * 1f;

        if (use == false)
        {
            if (-1 <= dely && dely <= 0)
            {
                animator.SetBool("TurnOn", true);
                use = true;
            }
        }
    }


    private void OnMouseDown()
    {
        DownWater();
    }

    public void DownWater()
    {
        if (wv.AnalogConnect == true && wv.GNDConnect == true && wv.VccConnect == true)
        {
            dely = mdely;

            if (use == true)
            {
                Debug.Log("zzz");
                animator.SetBool("TurnOn", false);
                use = false;
            }
        }
    }

    public void DownWaterRe()
    {
        if (use == true)
        {
            dely = mdely;
            animator.SetBool("TurnOn", false);
            use = false;
            wv.value = 0;
        }
    }
}
