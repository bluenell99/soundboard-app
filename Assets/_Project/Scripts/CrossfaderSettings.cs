using UnityEngine;

[CreateAssetMenu(menuName ="Settings/Crossfader Settings", fileName ="Crossfader Settings")]
public class CrossfaderSettings : ScriptableObject
{

    [Tooltip("Crossfader curve from track A to track B")]
    [SerializeField] private AnimationCurve _positiveCrossfaderCurve;

    [Tooltip("Crossfader curve from track B to track A")]
    [SerializeField] private AnimationCurve _negativeAnimationCurve;


    public AnimationCurve PositiveCrossfaderCurve => _positiveCrossfaderCurve;
    public AnimationCurve NegativeAnimationCurve => _negativeAnimationCurve;


}

