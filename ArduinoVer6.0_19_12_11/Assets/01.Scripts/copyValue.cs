using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class copyValue : MonoBehaviour
{

    public TextMesh target;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = target.text;
    }
}
