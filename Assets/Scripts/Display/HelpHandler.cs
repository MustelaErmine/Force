using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class HelpHandler : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    [SerializeField]
    [TextArea]
    string text;
    [HideInInspector]
    [SerializeField]
    TextMeshProUGUI textMesh;

    [SerializeField] int animationName;
    [SerializeField] Animator animator;

    public static HelpHandler Instance { get; private set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        Instance = this;
        //SetNormalText();
        if (animator != null)
            animator.SetInteger("Level", animationName);
        string levelName = SceneManager.GetActiveScene().name;
        if (!Save.Instance.IsTipDone(levelName))
        {
            ActivateChildren(true);
            Save.Instance.AddTipsDone(levelName);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
    void SetNormalText()
    {
        text = text.Replace("\n", " ");
        text = text.Replace("\r", " ");
        while (text.Contains("  "))
        {
            text = text.Replace("  ", " ");
        }
        textMesh.SetText(text);
    }

    void ActivateChildren(bool isActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }
}
