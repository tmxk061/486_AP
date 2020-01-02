using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug_cup : MonoBehaviour
{
    [SerializeField]
    public GameObject Water;

    float distance = 10;
    public bool waterCheck = false;
    public bool MouseClick = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "water" && waterCheck == false)
        {
            Water.SetActive(true);
        }
    }

    #region MouseDrag

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position.z - Camera.main.transform.position.z);
        
        distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

    }

    private void OnMouseUp()
    {
        MouseClick = false;
    }

    private void OnMouseDrag()
    {
        MouseClick = true;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance -= 10;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance += 10;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Sensor"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
                                                Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;

        }

    }

    #endregion MouseDrag
}
