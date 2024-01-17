using UnityEngine;
using UnityEngine.Audio;

public class VolumeFader : CustomSlider
{
    [SerializeField] private AudioSource _outputSource;
    private AudioManager _audioManager;

    protected override void InitDefaultSliderSettings()
    {
        _audioManager = AudioManager.Instance;


        Slider.maxValue = 1;
        Slider.minValue = 0;
        Slider.value = Slider.maxValue;

        OnSliderValueChanged();

    }

    protected override void OnSliderValueChanged()
    {
        _audioManager.Mixer.SetOutputVolume(_outputSource, Slider.value);
    }
}
