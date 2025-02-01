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
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
