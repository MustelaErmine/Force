using UnityEngine;

public class SaveDownloader : MonoBehaviour
{
    static bool complete = false;
    private void Awake()
    {
        if (!complete)
        {
            Save.Load();
            complete = true;
        }
    }
}