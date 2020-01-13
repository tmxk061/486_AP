using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashEventScript : MonoBehaviour, IDragHandler
{
    float distance = 10.0f;
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
 Input.mousePosition.y, distance);
        transform.position = mousePosition;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TrashCollider(other);
    }

    public void TrashCollider(Collider2D other)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(other.tag == "Block")
            {
                return;
            }
            Destroy(other.transform.gameObject);
        }
    }
}
