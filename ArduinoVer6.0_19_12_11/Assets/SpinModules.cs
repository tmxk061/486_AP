using UnityEngine;

public class SpinModules : MonoBehaviour
{
    #region

    public float rotationSpeed = 10.0f;
    public float lerpSpeed = 1.0f;

    private Vector3 speed = new Vector3();
    private Vector3 avgSpeed = new Vector3();

    private bool rotatecheck = false;

    #endregion

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            rotatecheck = true;
            speed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 2);
            transform.Rotate(Camera.main.transform.up * speed.x * rotationSpeed, Space.World);
            transform.Rotate(Camera.main.transform.right * speed.y * rotationSpeed, Space.World);
        }
    }

    //private void OnMouseExit()
    //{
    //    rotatecheck = false;
    //}
}