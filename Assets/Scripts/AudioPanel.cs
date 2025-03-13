using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string EffectsVolume = nameof(EffectsVolume);
    private const string BackroundMusicVolume = nameof(BackroundMusicVolume);

    [SerializeField] private AudioMixerGroup _audioMixer;

    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _shootAudioSource;
    [SerializeField] private AudioSource _punchAudioSource;
    [SerializeField] private AudioSource _footStepAudioSource;

    [SerializeField] private Button _toogleAllSoundsButton;
    [SerializeField] private Button _shootButton;
    [SerializeField] private Button _punchButton;
    [SerializeField] private Button _footStepButton;

    [SerializeField] private Slider _overallVolumeSlider;
    [SerializeField] private Slider _effectsVolumeSlider;
    [SerializeField] private Slider _backgroundMusicVolumeSlider;

    private float _volumeCorrection = 20;

    private bool _isSoundOn = true;

    private void OnEnable()
    {
        _toogleAllSoundsButton.onClick.AddListener(ToogleAllSounds);
        _shootButton.onClick.AddListener(_shootAudioSource.Play);
        _punchButton.onClick.AddListener(_punchAudioSource.Play);
        _footStepButton.onClick.AddListener(_footStepAudioSource.Play);
        _overallVolumeSlider.onValueChanged.AddListener(ChangeOveralVolume);
        _effectsVolumeSlider.onValueChanged.AddListener(ChangeEffectsVolume);
        _backgroundMusicVolumeSlider.onValueChanged.AddListener(ChangeBackGroundMusicVolume);
    }

    private void OnDisable()
    {
        _toogleAllSoundsButton.onClick.RemoveAllListeners();
        _shootButton.onClick.RemoveAllListeners();
        _punchButton.onClick.RemoveAllListeners();
        _footStepButton.onClick.RemoveAllListeners();
        _overallVolumeSlider.onValueChanged.RemoveAllListeners();
        _effectsVolumeSlider.onValueChanged.RemoveAllListeners();
        _backgroundMusicVolumeSlider.onValueChanged.RemoveAllListeners();
    }

    private void ChangeOveralVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * _volumeCorrection);
    }

    private void ChangeEffectsVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(EffectsVolume, Mathf.Log10(volume) * _volumeCorrection);
    }

    private void ChangeBackGroundMusicVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(BackroundMusicVolume, Mathf.Log10(volume) * _volumeCorrection);
    }

    private void ToogleAllSounds()
    {
        _isSoundOn = !_isSoundOn;

        if (_isSoundOn == true)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
    }
}
