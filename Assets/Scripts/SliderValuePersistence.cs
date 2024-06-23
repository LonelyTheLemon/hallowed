using UnityEngine;
using UnityEngine.UI;

public class SliderValuePersistence : MonoBehaviour
{
    public Slider slider;
    public string sliderPrefsKey = "SliderValue";
    public SliderData sliderData;

    private void Start()
    {
        LoadSliderValue();
        slider.onValueChanged.AddListener(UpdateSliderValue);
    }

    private void LoadSliderValue()
    {
        if (PlayerPrefs.HasKey(sliderPrefsKey))
        {
            float savedValue = PlayerPrefs.GetFloat(sliderPrefsKey);
            slider.value = savedValue;
        }
        else
        {
            slider.value = sliderData.sliderValue;
        }
    }

    private void UpdateSliderValue(float value)
    {
        sliderData.sliderValue = value;
        PlayerPrefs.SetFloat(sliderPrefsKey, value);
        PlayerPrefs.Save();
    }
}
