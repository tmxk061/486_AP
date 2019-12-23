using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCtrl_btn_click : MonoBehaviour
{
    [SerializeField]
    private GameObject back;

    Vector3 idleSize;
    Vector3 clickSize;

    float idle_spd =5f;
    float stay_spd = 100f;

    public float now_spd;

    // Start is called before the first frame update
    void Start()
    {
        now_spd = idle_spd;
        idleSize = back.transform.localScale;
        clickSize = back.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        back.transform.Rotate(0, 0, 1 * now_spd * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && now_spd == 100f)
        {
            back.transform.localScale = clickSize;
        }
        if (Input.GetMouseButtonUp(0))
        {
            back.transform.localScale = idleSize;
        }
    }

    private void OnMouseEnter()
    {
        now_spd = stay_spd;
    }

    private void OnMouseExit()
    {
        now_spd = idle_spd;
    }


}
