using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class CustomSlider : MonoBehaviour
{
    protected Slider Slider => _slider;
    private Slider _slider;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        InitDefaultSliderSettings();
    }

    protected abstract void OnSliderValueChanged();

    protected abstract void InitDefaultSliderSettings();

}
