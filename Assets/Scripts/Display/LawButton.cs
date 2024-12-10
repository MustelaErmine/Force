using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LawButton : MonoBehaviour
{
    readonly Color unselected = Color.white, selected = Color.cyan;
    bool isSelected = false;

    [SerializeField]
    LawEnum law;

    Image image;

    private void Awake()
    {
    }
    private void Start()
    {
        image = GetComponent<Image>();
        isSelected = LawsController.instance.enabledLaws.ToList().Contains(law);
        UpdateColor();
    }
    public void Supress()
    {
        isSelected = !isSelected;
        UpdateColor();
        UpdateLaw();
    }
    void UpdateColor()
    {
        if (isSelected)
        {
            image.color = selected;
        }
        else
        {
            image.color = unselected;
        }
    }
    void UpdateLaw()
    {
        if (isSelected)
        {
            LawsController.instance.EnableLaw(law);

        }
        else
        {
            LawsController.instance.DisableLaw(law);
        }
    }
}
