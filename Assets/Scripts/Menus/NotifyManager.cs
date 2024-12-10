using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyManager : MonoBehaviour
{
    public GameObject notifyPrefab;
    public static GameObject notifyStaticPrefab;
    public static NotifyManager instance;

    private void Start()
    {
        instance = this;
        notifyStaticPrefab = notifyPrefab;
    }

    public static void Notify(string text)
    {
        instance.NotifyLocal(text);
    }
    public void NotifyLocal(string text)
    {
        GameObject gameObject = Instantiate(notifyPrefab);
        gameObject.GetComponentInChildren<TMPro.TMP_Text>().SetText(text);
    }
}
