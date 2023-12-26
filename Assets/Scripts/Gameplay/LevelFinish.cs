using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            LevelManager.instance.EnterNextLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
