using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] Sprite _soundOnSprite;
    [SerializeField] Sprite _soundOffSprite;
    [SerializeField] Slider _slider;
    [SerializeField] Button _soundButton;
    public float _volume;

    private void Update()
    {
        AudioListener.volume = _slider.value;
        _volume = AudioListener.volume;
    }
    public void SoundToggleButton()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            _soundButton.image.sprite = _soundOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            _soundButton.image.sprite = _soundOffSprite;
        }
    }

    ///private void OnDestroy()
    //{
        //GlobalVolume.volume = _volume;
    //}

    //private void OnEnable()
    //{
        //if (GlobalVolume.volume != 0)
        //{
           // _volume = GlobalVolume.volume;
       // }
    //}

}
