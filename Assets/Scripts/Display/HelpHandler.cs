using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class HelpHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    LocaledString localedString;
    [SerializeField]
    [TextArea]
    string text;
    [SerializeField]
    TextMeshProUGUI textMesh;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        string localedText = localedString.Current;
        localedText = localedText.Replace("\n", " ");
        localedText = localedText.Replace("\r", " ");
        while (localedText.Contains("  "))
        {
            localedText = localedText.Replace("  ", " ");
        }
        textMesh.SetText(localedText);
        string levelName = SceneManager.GetActiveScene().name;
        if (!Save.Instance.IsTipDone(levelName))
        {
            ActivateChildren(true);
            Save.Instance.AddTipsDone(levelName);
        }
    }

    void ActivateChildren(bool isActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }
}
