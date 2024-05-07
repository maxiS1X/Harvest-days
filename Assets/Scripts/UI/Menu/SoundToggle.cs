using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] Slider _slider;
    public float oldVolume;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            _slider.value = 1.0f;
        }
        else
        {
            _slider.value = PlayerPrefs.GetFloat("volume");
        }
        oldVolume = _slider.value;
    }
    private void Update()
    {
        if(oldVolume != _slider.value)
        {
            PlayerPrefs.SetFloat("volume", _slider.value);
            PlayerPrefs.Save();
            oldVolume = _slider.value;
        }
    }
   

}
