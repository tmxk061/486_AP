using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_toggleButton : MonoBehaviour
{
    private bool clickCheck = false;
    public GameObject[] btnArr;
    

    public void Onclick()
    {
        if (clickCheck == false)
        {
            for (int i = 0; i < btnArr.Length; i++)
            {
                btnArr[i].SetActive(true);
                clickCheck = true;
            }
        }
        else if (clickCheck == true)
        {
            for (int i = 0; i < btnArr.Length; i++)
            {
                btnArr[i].SetActive(false);
                clickCheck = false;

            }
        }
    }


}
