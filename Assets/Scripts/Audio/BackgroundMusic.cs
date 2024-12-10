using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, LoadSceneMode mode)
    {
        if (!arg0.name.Contains("Level") && gameObject != null)
        {
            Destroy(gameObject);
            SceneManager.sceneLoaded -= SceneManager_activeSceneChanged;
        }
    }
}
