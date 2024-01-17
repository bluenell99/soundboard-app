using UnityEngine;
using UnityEngine.Audio;


[CreateAssetMenu(menuName = "Data/Mixer", fileName ="Mixer")]
public class Mixer : ScriptableObject
{
    [Header("Output Channels")]
    [SerializeField] private AudioMixerGroup _channelA;
    [SerializeField] private AudioMixerGroup _channelB;
    [SerializeField] private AudioMixerGroup _sampler;

    public AudioMixerGroup ChannelA => _channelA;
    public AudioMixerGroup ChannelB => _channelB;
    public AudioMixerGroup Sampler => _sampler;


    private const int MINIMUM_VOLUME = -80;

    /// <summary>
    /// Sets volume of a mixer group channel
    /// </summary>
    /// <param name="mixerGroup"></param>
    /// <param name="value"></param>
    /// 
    public void SetMixerVolume(AudioMixerGroup mixer, float value)
    {
        // Get volume parameter from mixer & check if exists
        string parameterName = $"Volume_{mixer.name}";
        bool exists = mixer.audioMixer.GetFloat(parameterName, out float currentValue);

        if (!exists)
        {
            LogService.Instance.Log($"No Parameter 'Volume' found on: {mixer.name}");
            return;
        }

        // Convert to decibels if value > 0, if value is 0, return minimum to avoid -infinity error
        float adjustedValue = value == 0 ? MINIMUM_VOLUME : AudioUtilities.ConvertToDecibel(value);

        // Set mixer parameter
        mixer.audioMixer.SetFloat(parameterName, adjustedValue);
    }


    /// <summary>
    /// Sets audio source volume property (overrides mixer)
    /// </summary>
    /// <param name="source"></param>
    /// <param name="value"></param>
    public void SetOutputVolume(AudioSource source, float value)
    {
        source.volume = value;
    }


    /// <summary>
    /// Crossfades from Mixer A to B by given value t (-1 to 1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void CrossFade(float a, float b)
    {
        SetMixerVolume(_channelA, a);
        SetMixerVolume(_channelB, b);
    }

}

public static class AudioUtilities
{
    /// <summary>
    /// Converts value to decibels (dB)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float ConvertToDecibel(float value)
    {
        float clampedValue = Mathf.Clamp01(value);
        return 20 * Mathf.Log10(clampedValue);
    }
}
