using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineArray : MonoBehaviour
{
    public List<GameObject> array = new List<GameObject>();

   // MouseOverArround moa;

    public void AllClear()
    {
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] != null)
            {
                array[i].SetActive(false);
                Destroy(array[i]);
            }
        }
    }
}
