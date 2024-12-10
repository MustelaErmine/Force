using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioHandler : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    AudioSource source;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = audioClip;
        GetComponent<Button>().onClick.AddListener(() => { source.Play(); });
    }
}
