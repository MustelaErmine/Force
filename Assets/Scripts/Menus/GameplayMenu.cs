using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] Image pausePanel;
    [SerializeField] Image winPanel;
    [SerializeField] Image[] stars;
    [SerializeField] Text moves;

    [SerializeField] Sprite starFilled;

    bool initialized = false;
    internal static bool pause = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        pause = false;
    }

    void Update()
    {
        if (!initialized)
        {
            initialized = true;
        }
    }

    public void OpenPause()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }

    public void ClosePause()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }

    public void ToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void OpenWinMenu()
    {
        winPanel.gameObject.SetActive(true);
        winPanel.GetComponent<AudioSource>().Play();
        string levelName = SceneManager.GetActiveScene().name;
        int starsCount = 0;
        if (Save.Instance.stars.ContainsKey(levelName))
        {
            starsCount = Save.Instance.stars[levelName];
        }

        for (int i = 1; i <= 3; i++)
        {
            if (starsCount >= i)
                stars[i - 1].sprite = starFilled;
        }
        moves.text = $"Ходов: {StarsHandler.instance.moves}";
        Time.timeScale = 0f;
    }
}
