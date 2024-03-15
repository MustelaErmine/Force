using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public string[] levels;

    public static LevelManager instance;

    public void Awake()
    {
        instance = this;
    }
    
    public string GetNextLevel(string thisScene)
    {
        int index = levels.ToList().IndexOf(thisScene);
        if (index == levels.Length - 1)
            return "SeasonChoice";
        return levels[index + 1];
    }
    public void NextLevel(string thisScene)
    {
        string to = GetNextLevel(thisScene);
        Save.Instance.levelDone.Add(thisScene);
        Save.Keep();
        SceneManager.LoadScene(to);
    }
    public void WinLevel()
    {

    }
    public void LoseLevel()
    {

    }
    public void ExitLevel()
    {

    }
}
