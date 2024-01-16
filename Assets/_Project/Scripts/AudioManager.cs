using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _trackA;
    [SerializeField] private AudioSource _trackB;

    private AudioMixerGroup _mixerGroupA;
    private AudioMixerGroup _mixerGroupB;

    public AudioMixerGroup MixerGroupA => _mixerGroupA;
    public AudioMixerGroup MixerGroupB => _mixerGroupB;


    protected override void Awake()
    {
        base.Awake();

        _mixerGroupA = _trackA.outputAudioMixerGroup;
        _mixerGroupB = _trackB.outputAudioMixerGroup;


    }

    public void CrossFade(float t)
    {

    }


    /// <summary>
    /// Sets volume of a mixer group channel
    /// </summary>
    /// <param name="mixerGroup"></param>
    /// <param name="value"></param>
    public void SetMixerVolume(AudioMixerGroup mixerGroup, float value)
    {

        string parameterName = $"Volume_{mixerGroup.name}";
        bool exists = mixerGroup.audioMixer.GetFloat(parameterName, out float currentValue);

        if (!exists)
        {
            LogService.Instance.Log($"No Parameter 'Volume' found on: {mixerGroup.name}");
            return;
        }

        mixerGroup.audioMixer.SetFloat(parameterName, value);
    }
}



