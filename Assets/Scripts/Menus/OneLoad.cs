using PlayablesStudio.Plugins.YandexGamesSDK.Runtime;
using System.Collections;
using UnityEngine;

public class OneLoad : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LoadRoutine());
    }
    IEnumerator LoadRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        YandexGamesSDK.Instance.SetGameplayReady();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
