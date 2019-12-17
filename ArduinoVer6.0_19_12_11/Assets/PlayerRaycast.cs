using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public new GameObject camera;
    public RaycastHit hit;
    public Ray ray;

    [SerializeField]
    private GameObject Myobject;

    public Vector3 pointting;//위치를 가져옴

    [SerializeField]
    private GameObject NowArround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.transform.position, camera.transform.forward * 400.0f, Color.red);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 400.0f))
        {
            if (hit.collider != null)
            {
                if (NowArround != null)
                {
                    if (hit.transform.gameObject != NowArround)
                    {
                        NowArround.GetComponent<MouseOverArround>().OnMouseExit();
                    }
                }

                if (hit.transform.tag == "Arround")
                {
                    NowArround = hit.transform.gameObject;
                    hit.collider.gameObject.GetComponent<MouseOverArround>().OnMouseEnter();
                }

            }



            if (Input.GetMouseButtonDown(0))
            {
                switch (hit.collider.name)
                {
                    case "BlockCordingButton":
                        hit.collider.gameObject.GetComponent<OnCubeClick>().OnMouseDown();
                        break;
                }

                if (hit.collider.tag == "Sensor")
                {
                    Myobject = hit.collider.gameObject;
                    Myobject.transform.parent = camera.transform;
                }

                
            }
            else if (Input.GetMouseButtonUp(0))
            {
                try
                {
                    Myobject.transform.parent = null;
                }
                catch
                {

                }
            }
        }
       
            

       

    }
}
