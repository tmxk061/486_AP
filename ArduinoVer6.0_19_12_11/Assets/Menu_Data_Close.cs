using UnityEngine;

public class Menu_Data_Close : MonoBehaviour
{
    public GameObject Parent;

    public void OnBtnClick()
    {
        Parent.SetActive(false);
    }
}