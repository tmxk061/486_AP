using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    //public GameObject door;
    Animator animator;
    // bool autodoor;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider col)
    { 
        if (col.gameObject.tag == "Player")
        {
 
            animator.SetBool("AutoDoor", true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        //if (col.gameObject.tag == "Player")
        //{
            Debug.Log("In");
            animator.SetBool("AutoDoor", false);
        //}
    }
}
