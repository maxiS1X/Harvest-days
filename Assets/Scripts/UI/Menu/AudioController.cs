using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioListener Listener;

    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            AudioListener.volume = 1.0f;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
