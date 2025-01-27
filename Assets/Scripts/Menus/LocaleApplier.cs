using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocaleApplier : MonoBehaviour
{
    [SerializeField] LocaledString localedString;
    [SerializeField] TMPro.TextMeshProUGUI textMesh;
    [SerializeField] Text text;
    void Start()
    {
        if (text != null)
            text.text = localedString.Current;
        if (textMesh != null)
            textMesh.text = localedString.Current;
    }
}
