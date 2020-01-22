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
        ColorSet(0, 0, 255);

        //int i = Random.Range(1, 4);

        //if (i == 1)
        //    ColorSet(255, 0, 0);
        //else if(i == 2)
        //    ColorSet(0, 255, 0);
        //else
        //    ColorSet(0, 0, 255);

    }

    public void ColorSet(int r, int g, int b)
    {
        lineRenderer.material.color = new Color(r, g, b);
        //lineRenderer.material.color=Random.ColorHSV();
    }

    public void LastLineSetting()
    {
        lineRenderer.startWidth = 2;
        lineRenderer.endWidth = 2;
        ColorSet(255, 255, 0);

    }

    public void DefaultLineSetting()
    {
        lineRenderer.startWidth = 1;
        lineRenderer.endWidth = 1;
        ColorSet(0, 0, 255);

    }
}