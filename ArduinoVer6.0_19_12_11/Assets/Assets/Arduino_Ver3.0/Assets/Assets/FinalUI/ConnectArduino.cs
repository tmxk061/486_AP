using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ConnectArduino : MonoBehaviour
{
    [SerializeField]
    StartBlock blockgroup;

    [SerializeField]
    public Material TurnOn;

    [SerializeField]
    public Material TurnOff;

    private MeshRenderer MeshPrint;

    void Start()
    {
        MeshPrint = this.gameObject.GetComponent<MeshRenderer>();
        blockgroup = GameObject.FindWithTag("Block").GetComponent<StartBlock>();
    }

    // 버튼 클릭
    public void OnMouseDown()
    {
        //StartCoroutine(ClickEffect());

        StartCoroutine(blockgroup.GetMergeCode());
    }

    // 클릭시 버튼 깜박임
    IEnumerator ClickEffect()
    {
        SetMeshMaterial(true);
        yield return new WaitForSeconds(0.5f); //0.5초 불들어옴
        SetMeshMaterial(false);
    }

    // 버튼 마테리얼 변경
    public void SetMeshMaterial(bool on)
    {
        if (on == true)
            MeshPrint.material = TurnOn;
        else if (on == false)
            MeshPrint.material = TurnOff;

    }
}
