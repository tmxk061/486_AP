using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoTemp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;
    public GameObject spwnPoint;

    public GameObject Tootip;

    public TemperToggle type;

    public void ClickEvent()
    {
        TempHumiParent ultval = Instantiate(obj, spwnPoint.transform.position, spwnPoint.transform.rotation).GetComponent<TempHumiParent>();
        ultval.temperToggle = type;
        ultval.gameObject.transform.parent = GameObject.Find("CraftTable").transform;
    }

    public GameObject ClickEventReturn()
    {
        GameObject Newobj = Instantiate(obj, spwnPoint.transform.position, spwnPoint.transform.rotation);
        TempHumiParent ultval = Newobj.GetComponent<TempHumiParent>();
        ultval.temperToggle = type;
        ultval.gameObject.transform.parent = GameObject.Find("CraftTable").transform;

        return Newobj;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tootip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tootip.SetActive(false);
    }
}