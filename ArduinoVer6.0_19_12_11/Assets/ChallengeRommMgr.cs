using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeRommMgr : MonoBehaviour
{
    public bool Lock;
    public BoxCollider[] colliderArray;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Lock = true;
            for (int i = 0; i < colliderArray.Length; i++)
            {
                colliderArray[i].enabled = false;
            }
           
        }
       
    }
}
