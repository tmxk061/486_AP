using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropCompare : MonoBehaviour
{
    [SerializeField]
    public Dropdown drop;

    public ifBlock ifblock;
    // Start is called before the first frame update
    void Awake()
    {
        ifblock = this.gameObject.GetComponentInParent<ifBlock>();
    }
    void Start()
    {
        ifblock = this.gameObject.GetComponentInParent<ifBlock>();
    }

    public void ChangeValue()
    {
        ifblock.SecondSel = drop.value;

    }
}
