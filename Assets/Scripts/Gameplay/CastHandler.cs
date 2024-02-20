using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastHandler : MonoBehaviour
{
    public static IArrowDisplay arrow;
    [SerializeField] GameObject[] arrowPrefab;
    static Movable _chosenMovable = null;
    public static Movable ChosenMovable
    {
        get => _chosenMovable; set {
            if (_chosenMovable != null)
                _chosenMovable.IsChosen = false;
            _chosenMovable = value;
        }
    }

    void Start()
    {
        GameObject _arrow = Instantiate(arrowPrefab[Save.Instance.cosmeticArrow]);
        arrow = _arrow.GetComponent<IArrowDisplay>();
    }
}
