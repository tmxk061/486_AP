using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyColor : MonoBehaviour
{
    [SerializeField]
    private Image Mycolor_p;

    [SerializeField]
    private Image Mycolor_c;

    [SerializeField]
    private Color c;
    // Start is called before the first frame update
    void Start()
    {
        c = new Color(Random.value, Random.value, Random.value,1f);
        //고유 색 지정
        Mycolor_p.color = c;
        Mycolor_c.color = c;

    }

   
}
