using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usetoilet : MonoBehaviour
{
    Animator animator;

    public WaterValue wv;
    public GameObject Green;

    [SerializeField]
    float dely;
    public float maxdely;

    bool use;

    void Start()
    {
        dely = -5;

        animator = GetComponent<Animator>();
        use = true;

        animator.SetBool("TurnOn", true);
    }

    private void Update()
    {

        dely -= Time.deltaTime * 1f;

        if (-2 <= dely && dely <= 0)
        {
            use = true;
            animator.SetBool("TurnOn", true);
        }
    }

    private void OnMouseDown()
    {
        if (wv.AnalogConnect == true && wv.GNDConnect == true && wv.VccConnect == true && Green.activeSelf == true)
        {
            if (use == true)
            {
                animator.SetBool("TurnOn", false);
                use = false;

                dely = maxdely;
                return;
            }
        }

        //else if (use == false)
        //{
        //    Debug.Log("bbb");
        //    animator.SetBool("TurnOn", true);
        //    use = true;

        //    return;
        //}

        //if (Green.activeSelf == true)
        //{
        //    Debug.Log("in");
        //    if (use == true)
        //    {
        //        Debug.Log("in2");
        //        use = false;
        //        animator.SetBool("TurnOn", false);
        //    }
        //    animator.SetBool("TurnOn", true);
        //}
    }
}
