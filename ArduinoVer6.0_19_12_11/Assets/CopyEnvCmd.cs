using UnityEngine;
using UnityEngine.UI;

public class CopyEnvCmd : MonoBehaviour
{
    public Dropdown EnvChangeOrigin;
    public Dropdown EnvChangeCopy;


    public Toggle RainStartCopy;
    public Slider RainSlideCopy;

    public Toggle RainStartOrigin;
    public Slider RainSlideOrigin;

    public Toggle SnowStartCopy;
    public Slider SnowSlideCopy;

    public Toggle SnowStartOrigin;
    public Slider SnowSlideOrigin;

    public Toggle LightCopy;
    public Slider LightSliderCopy;
    public Toggle LightCenterCopy;
    public Toggle LightAllCopy;

    public Toggle LightOrigin;
    public Slider LightSliderOrigin;
    public Toggle LightCenterOrigin;
    public Toggle LightAllOrigin;

    public Toggle WATEROrigin;
    public Toggle Water1Origin;
    public Toggle Water2Origin;
    public Toggle Water3Origin;

    public Toggle WATERCopy;
    public Toggle Water1OCopy;
    public Toggle Water2Copy;
    public Toggle Water3Copy;

    // Update is called once per frame
    private void Update()
    {
        EnvChangeOrigin.value = EnvChangeCopy.value;

        RainStartOrigin.isOn = RainStartCopy.isOn;
        RainSlideOrigin.value = RainSlideCopy.value;

        SnowStartOrigin.isOn = SnowStartCopy.isOn;
        SnowSlideOrigin.value = SnowSlideCopy.value;

        LightOrigin.isOn = LightCopy.isOn;
        LightSliderOrigin.value = LightSliderCopy.value;
        LightCenterOrigin.isOn = LightCenterCopy.isOn;
        LightAllOrigin.isOn = LightAllCopy.isOn;

        WATEROrigin.isOn = WATERCopy.isOn = true;
        Water1Origin.isOn = Water1OCopy.isOn;
        Water2Origin.isOn = Water2Copy.isOn;
        Water3Origin.isOn = Water3Copy.isOn;

        //WATERCopy.isOn = WATEROrigin.isOn;
        //Water1OCopy.isOn = Water1Origin.isOn;
        //Water2Copy.isOn = Water2Origin.isOn;
        //Water3Copy.isOn = Water3Origin.isOn;
    }
}