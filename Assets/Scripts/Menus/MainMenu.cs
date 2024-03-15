using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button left, right;
    [SerializeField] Button[] levelButtons;

    int startIndex = 0;
    const int buttonsOnScreen = 6;
    void Start()
    {
        UpdateButtons();
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SwipeList(int by)
    {
        startIndex += by;
        startIndex = Mathf.Min(LevelManager.instance.levels.Length - buttonsOnScreen, startIndex);
        startIndex = Mathf.Max(0, startIndex);
        UpdateButtons();
    }
    
    void UpdateButtons()
    { /*
        for (int i = 0; i < buttonsOnScreen; i++)
        {
            levelButtons[i].GetComponentInChildren<Text>().text = (startIndex + i).ToString();
            levelButtons[i].interactable = Save.Instance.lastLevel >= i;
            if (!levelButtons[i].interactable)
            {
                levelButtons[i].GetComponentInChildren<Text>().color = new Color(9,9,9);
            }
        }
        */
        left.interactable = startIndex != 0;
        right.interactable = startIndex != LevelManager.instance.levels.Length - buttonsOnScreen;
    }

    public void LevelButton(int index)
    {
        SceneManager.LoadScene(LevelManager.instance.levels[startIndex + index]);
    }
}
