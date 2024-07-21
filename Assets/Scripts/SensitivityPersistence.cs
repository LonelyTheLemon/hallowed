using UnityEngine;
using UnityEngine.UI;

public class SensitivityPresistence : MonoBehaviour
{

    public Slider SensitivitySlider;
    public string SensitivitySliderPrefsKey = "SensitivitySliderValue";
    public SliderData SensitivitySliderData;

    private void Start()
    {
        LoadSliderValue(SensitivitySlider, SensitivitySliderPrefsKey, SensitivitySliderData);
        SensitivitySlider.onValueChanged.AddListener(value => UpdateSliderValue(value, SensitivitySliderPrefsKey, SensitivitySliderData));
    }

    private void LoadSliderValue(Slider slider, string prefsKey, SliderData sliderData)
    {
        if (PlayerPrefs.HasKey(prefsKey))
        {
            float savedValue = PlayerPrefs.GetFloat(prefsKey);
            slider.value = savedValue;
        }
        else
        {
            slider.value = sliderData.sliderValue;
        }
    }

    private void UpdateSliderValue(float value, string prefsKey, SliderData sliderData)
    {
        sliderData.sliderValue = value;
        PlayerPrefs.SetFloat(prefsKey, value);
        PlayerPrefs.Save();
    }
}
