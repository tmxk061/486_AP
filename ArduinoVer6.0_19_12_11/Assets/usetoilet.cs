using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usetoilet : MonoBehaviour
{
    Animator animator;
     bool use;

    public WaterValue wv;
    public TextMesh wateralue;

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
        if (wateralue.text == "")
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
}
