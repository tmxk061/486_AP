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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(camera.transform.position, camera.transform.forward * 400.0f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 400.0f))
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
