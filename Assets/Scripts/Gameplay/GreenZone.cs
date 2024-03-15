using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            LevelManager.instance.WinLevel();
    }
}
