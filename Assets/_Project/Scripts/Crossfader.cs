using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crossfader : CustomSlider
{

    [SerializeField] private CrossfaderSettings _crossfaderSettings;
    private AudioManager audioManager;

    protected override void Awake()
    {
        base.Awake();
        audioManager = AudioManager.Instance;
    }

    protected override void OnSliderValueChanged()
    {
        Debug.Log("Crossfader value changed");
        
        audioManager.SetMixerVolume(audioManager.MixerGroupA, _crossfaderSettings.PositiveCrossfaderCurve.Evaluate(Slider.value));
        audioManager.SetMixerVolume(audioManager.MixerGroupB, _crossfaderSettings.NegativeAnimationCurve.Evaluate(Slider.value));
    }

}
