using UnityEngine;

public class OneLoad : MonoBehaviour
{
    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
