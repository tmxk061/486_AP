using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usetoilet : MonoBehaviour
{
    Animator animator;
     bool use;

    void Start()
    {
        use = true;

        animator = GetComponent<Animator>();

        toiltrue();
    }

    private void OnMouseDown()
    {
        Debug.Log("1111");

        if (use == true)
        {
            use = false;
            toifalse();

        }
        else if (use == false)
        {
            use = true;
            toiltrue();
        }
    }

    private void toiltrue()
    {
        animator.SetBool("TurnOn", true);
    }

    private void toifalse()
    {
        animator.SetBool("TurnOn", false);

    }
}
