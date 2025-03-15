using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private Button _toogleButton;

    private bool _isSoundsOn = true;

    private void OnEnable()
    {
        _toogleButton.onClick.AddListener(ToogleAllSounds);
    }

    private void OnDisable()
    {
        _toogleButton.onClick.RemoveListener(ToogleAllSounds);
    }

    private void ToogleAllSounds()
    {
        _isSoundsOn = !_isSoundsOn;

        if (_isSoundsOn == true)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
    }
}
