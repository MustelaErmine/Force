using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public static IArrow arrow;
    [SerializeField] GameObject[] arrowPrefab;
    void Start()
    {
        GameObject _arrow = Instantiate(arrowPrefab[Save.Instance.cosmeticArrow]);
        arrow = _arrow.GetComponent<IArrow>();
    }
}
