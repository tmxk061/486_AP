using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;
    public GameObject spwnPoint;

    public GameObject Tootip;

    public void Start()
    {
     
    }

    public void ClickEvent()
    {
        int num = 0;

         num = Random.Range(0, 4);

        Instantiate(obj, spwnPoint.transform.position, spwnPoint.transform.rotation);

        //obj.SetActive(true);
    }

    public GameObject ClickEventReturn()
    {
        int num = 0;

        num = Random.Range(0, 4);

        GameObject newObj = Instantiate(obj, spwnPoint.transform.position, spwnPoint.transform.rotation);

        return newObj;
        //obj.SetActive(true);
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
