using UnityEngine;
using UnityEngine.UI;

public class SliderValuePersistence : MonoBehaviour
{
    public Slider GameSlider;
    public string GameSliderPrefsKey = "GameSliderValue";
    public SliderData GameSliderData;

    public Slider MusicSlider;
    public string MusicSliderPrefsKey = "MusicSliderValue";
    public SliderData MusicSliderData;

    public Slider SensitivitySlider;
    public string SensitivitySliderPrefsKey = "SensitivitySliderValue";
    public SliderData SensitivitySliderData;

    private void Start()
    {
        LoadSliderValue(GameSlider, GameSliderPrefsKey, GameSliderData);
        GameSlider.onValueChanged.AddListener(value => UpdateSliderValue(value, GameSliderPrefsKey, GameSliderData));

        LoadSliderValue(MusicSlider, MusicSliderPrefsKey, MusicSliderData);
        MusicSlider.onValueChanged.AddListener(value => UpdateSliderValue(value, MusicSliderPrefsKey, MusicSliderData));

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
