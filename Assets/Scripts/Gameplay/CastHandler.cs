using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastHandler : MonoBehaviour
{
    public  IArrowDisplay arrow = null;
    [SerializeField] GameObject[] arrowPrefab;
    Movable _chosenMovable = null;
    public static CastHandler instanse;
    public AudioSource audioSource;
    [SerializeField] AudioClip slideClip, fastClip;
    public static Movable ChosenMovable
    {
        get => instanse._chosenMovable; 
        set {
            if (instanse._chosenMovable != null)
                instanse._chosenMovable.IsChosen = false;
            instanse._chosenMovable = value;
        }
    }
    public static void Clear()
    {
        instanse.arrow = null;
        instanse._chosenMovable = null;
    }

    void Start()
    {
        if (instanse != null && instanse.gameObject.activeSelf)
            return;
        instanse = this;
        if (arrow == null)
        {
            GameObject _arrow = Instantiate(arrowPrefab[Save.Instance.cosmeticArrow]);
            _arrow.transform.position = new Vector2(20, 20);
            arrow = _arrow.GetComponent<IArrowDisplay>();
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySlide()
    {
        audioSource.clip = slideClip;
        audioSource.Play();
    }
    public void PlayFast()
    {
        audioSource.clip = fastClip;
        audioSource.Play();
    }
}
