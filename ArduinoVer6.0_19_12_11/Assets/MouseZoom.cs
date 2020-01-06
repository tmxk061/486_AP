using UnityEngine;

public class MouseZoom : MonoBehaviour
{
    private Camera myCam;
    private float firstSize;
    private Vector3 firstPos;

    private void Start()
    {
        myCam = GetComponent<Camera>();
        firstSize = myCam.orthographicSize;
        firstPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                this.transform.position = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
            }

            myCam.orthographicSize = 15f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            myCam.orthographicSize = firstSize;
            transform.position = firstPos;
        }
    }
}