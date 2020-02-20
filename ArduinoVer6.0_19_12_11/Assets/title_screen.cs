using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_screen : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadingSceneManager.LoadScene("Main_Stage");
        }
        //SceneManager.LoadScene("Main_Stage");
       
    }
}
