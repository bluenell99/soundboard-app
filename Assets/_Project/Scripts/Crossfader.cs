using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crossfader : CustomSlider
{
    [SerializeField] private CrossfaderSettings _crossfaderSettings;

    [Range(-1,1)]
    [SerializeField] private int _defaultValue;

    private AudioManager _manager;

    protected override void InitDefaultSliderSettings()
    {

        _manager = AudioManager.Instance;

        Slider.minValue = -1;
        Slider.maxValue = 1;

        Slider.value = Slider.minValue;

        OnSliderValueChanged();

    }

    protected override void OnSliderValueChanged()
    {
        Debug.Log("Crossfader value changed");

        float a = _crossfaderSettings.PositiveCrossfaderCurve.Evaluate(Slider.value);
        float b = _crossfaderSettings.NegativeAnimationCurve.Evaluate(Slider.value);

        _manager.Mixer.CrossFade(a,b );
        
    }
}
