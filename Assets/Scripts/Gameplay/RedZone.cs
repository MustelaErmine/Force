using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    AudioSource source;
    public void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = true;
        source.clip = ESAudioContainer.ghoul;
        source.volume = 0.3f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movable>() != null)
        {
            collision.GetComponent<Movable>().blockers.Add(GetHashCode());

            source.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movable>() != null)
        {
            collision.GetComponent<Movable>().blockers.Remove(GetHashCode());
            source.Stop();
        }
    }
}
