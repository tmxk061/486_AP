using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanScript : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("TurnOn", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
