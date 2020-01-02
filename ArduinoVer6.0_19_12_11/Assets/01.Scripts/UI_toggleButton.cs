using UnityEngine;

public class UI_toggleButton : MonoBehaviour
{
    public bool clickCheck = false;
    public GameObject btnArr;
    public GameObject[] ElsebtnArr;
    public GameObject[] ElsebtnCmd;

    public void Onclick()
    {
        if (clickCheck == false)
        {
            btnArr.SetActive(true);
            for (int i = 0; i < ElsebtnArr.Length; i++)
            {
                ElsebtnCmd[i].GetComponent<UI_toggleButton>().clickCheck = false;
                ElsebtnArr[i].SetActive(false);
            }
            clickCheck = true;
        }
        else if (clickCheck == true)
        {
            btnArr.SetActive(false);
            clickCheck = false;
        }
    }
}