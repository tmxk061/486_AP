using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_Title : MonoBehaviour
{
    public void OnBackTitleBtn()
    {
        SceneManager.LoadScene("Title");
    }
}
