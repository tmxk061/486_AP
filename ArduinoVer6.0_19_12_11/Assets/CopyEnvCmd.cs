using UnityEngine;
using UnityEngine.UI;

public class CopyEnvCmd : MonoBehaviour
{
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

    // Update is called once per frame
    private void Update()
    {
        RainStartOrigin.isOn = RainStartCopy.isOn;
        RainSlideOrigin.value = RainSlideCopy.value;

        SnowStartOrigin.isOn = SnowStartCopy.isOn;
        SnowSlideOrigin.value = SnowSlideCopy.value;

        LightOrigin.isOn = LightCopy.isOn;
        LightSliderOrigin.value = LightSliderCopy.value;
        LightCenterOrigin.isOn = LightCenterCopy.isOn;
        LightAllOrigin.isOn = LightAllCopy.isOn;
    }
}