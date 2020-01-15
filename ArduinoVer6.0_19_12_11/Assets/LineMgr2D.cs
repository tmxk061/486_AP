using UnityEngine;

public class LineMgr2D : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField]
    public Transform Point1;

    [SerializeField]
    public Transform Point2;

    private void Awake()
    {
        //라인렌더러 설정
        lineRenderer = GetComponent<LineRenderer>();
        ColorSet(255, 0, 0);
        //UpdateLine();
    }

    public void Point1Set(Vector3 Moveposition)
    {
        Point1.transform.position = Moveposition;
    }

    public void Point2Set(Vector3 Moveposition)
    {
        Point2.transform.position = Moveposition;
    }

    public void UpdateLine()
    {
        //라인렌더러 처음위치 나중위치
        lineRenderer.SetPosition(0, Point1.position);
        lineRenderer.SetPosition(1, Point2.position);
    }

    public void ColorSet(int r, int g, int b)
    {
        lineRenderer.material.color = new Color(r, g, b);
        //lineRenderer.material.color=Random.ColorHSV();
    }
}