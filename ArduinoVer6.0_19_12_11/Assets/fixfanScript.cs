using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixfanScript : MonoBehaviour
{
    Animator animator;
    public DCPlus dcp;
    public DCMin dcm;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
        
    void Update()
    {
        On();
    }

    private void On()
    {
        if (dcp.Connect == true && dcm.Connect == true)
        {
            animator.SetBool("TurnOn", true);
        }

    }
}
