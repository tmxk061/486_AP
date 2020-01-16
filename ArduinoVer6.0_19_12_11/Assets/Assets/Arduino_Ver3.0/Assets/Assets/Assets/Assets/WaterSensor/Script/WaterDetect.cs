using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 물 오브젝트 충돌시 감지
/// </summary>
public class WaterDetect : MonoBehaviour
{
    public int value;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "water")
        {
            value += 50;
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log(other);

        if (other.tag == "water")
        {
            value -= 50;
        }
    }
}
