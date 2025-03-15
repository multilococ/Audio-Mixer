using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    [SerializeField] private Slider _slider;

    private float _minSliderValue = 0.0001f;
    private float _volumeCorrection = 20;

    private void Awake()
    {
        _slider.minValue = _minSliderValue;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(_audioMixer.name, Mathf.Log10(volume) * _volumeCorrection);
    }
}