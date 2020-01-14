using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heaterSwitch : MonoBehaviour
{
    Animator animator;

    public TextMesh temp;
    public TextMesh humi;

    public GameObject On;
    public GameObject Off;

    bool heater;

    void Start()
    {
        animator = GetComponent<Animator>();

        heater = false;

        On.SetActive(false);
        Off.SetActive(true);
    }

    void Update()
    {
        temphumi();
    }

    void temphumi()
    {
        if (temp.text != "" && humi.text != "")
        {
            if (heater == false)
            {
                heater = true;
                animator.SetBool("TurnOn", true);

                On.SetActive(true);
                Off.SetActive(false);
            }
        }
        else if (temp.text == "" && humi.text == "")
        {
            if (heater == true)
            {
                heater = false;
                animator.SetBool("TurnOn", false);

                On.SetActive(false);
                Off.SetActive(true);
            }
        }
    }
}
