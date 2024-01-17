using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _trackA;
    [SerializeField] private AudioSource _trackB;
    [SerializeField] private AudioSource _sampler;

    [SerializeField] private Mixer _mixer;

    public Mixer Mixer => _mixer;

    public AudioSource Sampler => _sampler;
    public AudioSource TrackA => _trackA;
    public AudioSource TrackB => _trackB;


    protected override void Awake()
    {
        base.Awake();
    }



}



