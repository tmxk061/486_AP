﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UltFirstDrop : MonoBehaviour
{

    UltBlock ultBlock;
    [SerializeField]
    Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        ultBlock = this.gameObject.GetComponentInParent<UltBlock>();
    }

    public void SetContent()
    {
        ultBlock.SetNum(dropdown.value);
    }
}
