using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{
    public static SeasonContainer seasonContainer;
    public SeasonContainer localSeasonContainer;

    public GameplayMenu menu;

    public static LevelManager instance;

    public void Awake()
    {
        instance = this;
        if (localSeasonContainer != null && seasonContainer == null)
        {
            seasonContainer = localSeasonContainer;
        }
    }

    public void LoadNextLevel()
    {
        CastHandler.Clear();
        string thisScene = SceneManager.GetActiveScene().name;
        string to = seasonContainer.GetNextLevel(thisScene);
        if (to != null)
            GoToLevel(to);
        else
            SceneManager.LoadScene(seasonContainer.GetLevelSeasonName(thisScene));
    }
    public void RestartLevel()
    {
        CastHandler.Clear();
        Time.timeScale = 1;
        GameplayMenu.pause = false;
        GoToLevel(SceneManager.GetActiveScene().name);
    }
    public void HandleWinLevel()
    {
        GameplayMenu.pause = false;
        Save.Instance.AddDoneLevel(SceneManager.GetActiveScene().name);
        StarsHandler.instance.PretendStars();
        Save.Keep();

        menu.OpenWinMenu();
    }
    public void HandleLoseLevel()
    {
        RestartLevel();
    }
    public void ExitLevel()
    {
        CastHandler.Clear();
        SceneManager.LoadScene(seasonContainer.GetLevelSeasonName());
    }
    public static void GoToLevel(string levelName)
    {
        print(AdsHandler.instance);
        if (UnityEngine.Random.value < 0.3f && AdsHandler.instance != null && !Save.Instance.adfree)
            AdsHandler.instance.ShowInterstitial(levelName);
        else
            SceneManager.LoadScene(levelName);
    }
}
