using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{

    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResolution()
    {
        if(dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if (dropdown.value == 1)
        {
            Screen.SetResolution(1280, 720, false);
            Debug.Log("1280,720");
        }
        else if (dropdown.value == 2)
        {
            Screen.SetResolution(1600, 900, false);
        }
        else
        {
            Screen.SetResolution(1024, 600, false);
        }
    }
}
