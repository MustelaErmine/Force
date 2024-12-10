using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsHandler : MonoBehaviour
{
    AudioSource audioSource;
    Slider slider;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        slider.value = Save.Instance.audioSetting;
    }

    public void ValueChanged()
    {
        float value = slider.value;
        Save.Instance.ApplyVolume(value);
        //print(value);
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
