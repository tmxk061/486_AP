using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewCam_setting : MonoBehaviour
{
    int i_width;
    int i_height;

    Camera ViewCam;

    [SerializeField]
    private Canvas ViewrScreen;

    // Start is called before the first frame update
    void Start()
    {
        ViewCam = GetComponent<Camera>();
        i_width = Screen.width;
        i_height = Screen.height;

        Debug.Log(i_width + ":" + i_height);

        ViewResolSetting(i_width, i_height);

    }

    public void ViewResolSetting(int width, int height)
    {
        if (width == 1920 && height == 1080)
        {
            ViewCam.orthographicSize = 957;
            ViewrScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080);
        }
        else if (width == 1280 && height == 720)
        {
            ViewCam.orthographicSize = 640;
            ViewrScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(1280, 720);
        }
        else if (width == 1600 && height == 900)
        {
            ViewCam.orthographicSize = 800;
            ViewrScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(1600, 900);
        }
        else if (width == 1024 && height == 600)
        {
            ViewCam.orthographicSize = 500;
            ViewrScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(1024, 600);
        }
    }

  
}
