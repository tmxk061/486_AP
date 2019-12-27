using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class RunButton : MonoBehaviour
{
    [SerializeField]
    StartBlock blockgroup;
    // Start is called before the first frame update
    public bool RunOn = true;
    [SerializeField]
    public Animator shellter;

    public UnityEngine.UI.Toggle AllLightToggle;
    public UnityEngine.UI.Toggle CenterLightToggle;
    public Animator PannelDown;

    [SerializeField]
    public Material TurnOn;

    [SerializeField]
    public Material TurnOff;

    private MeshRenderer MeshPrint;

    

    public void Start()
    {
      
        MeshPrint = this.gameObject.GetComponent<MeshRenderer>();
    }
    public void SearchBlock()
    {
        
        //blockgroup = GameObject.FindWithTag("Block").GetComponent<StartBlock>();
       
    }

    private void OnMouseDown()
    {
       
        //====================================
        PannelDown.SetBool("PannelMove", true);
        AllLightToggle.isOn = false;
        CenterLightToggle.isOn = true;
        //====================================
        SetMeshMaterial(true);
        RunOn = true;
        shellter.SetBool("PannelMove",true);
        Work();


    }

    public void Work()
    {
        StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        while (RunOn == true)
        {
            Debug.Log("런온");
            if (blockgroup != null)
            {
                Debug.Log("블록그룹");

                yield return StartCoroutine(blockgroup.Run());
            }
        }
        yield return new WaitForSeconds(1);
    }

    public void SetMeshMaterial(bool on)
    {
        try
        {
            if (on == true)
                MeshPrint.material = TurnOn;
            else if (on == false)
                MeshPrint.material = TurnOff;
        }
        catch
        {

        }
       

    }

  
}
