using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESAudioContainer : MonoBehaviour
{
    [SerializeField] AudioClip localGhoul;
    public static AudioClip ghoul;

    void Start()
    {
        ghoul = localGhoul;
    }
}
