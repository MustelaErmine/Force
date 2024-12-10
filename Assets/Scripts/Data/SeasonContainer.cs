using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "Seasons", menuName = "ScriptableObjects/SeasonContainer", order = 1)]
public class SeasonContainer : ScriptableObject
{
    public SeasonData[] seasons;

    public SeasonData GetLevelSeason(string level)
    {
        foreach (SeasonData season in seasons) {
            if (season.levels.Any((LevelData data) => data.levelName == level)) {
                return season;
            }
        }
        return null;
    }
    public string GetNextLevel(string level)
    {
        SeasonData season = GetLevelSeason(level);
        if (season == null) 
        { 
            return null; 
        }
        int index = season.levels.ToList().FindIndex(i => i.levelName == level);
        if (index == -1)
            return null;
        if (index >= season.levels.Count() - 1)
            return null;
        return season.levels[index + 1].levelName;
    }
    public string GetLevelSeasonName(string level)
    {
        SeasonData season = GetLevelSeason(level);
        return season != null ? season.seasonName : null;
    }
    public string GetLevelSeasonName()
    {
        return GetLevelSeasonName(SceneManager.GetActiveScene().name);
    }
    public bool IsPreviousDone(string thisName)
    {
        SeasonData season = GetLevelSeason(thisName);
        int index = season.levels.ToList().FindIndex(i => i.levelName == thisName);
        if (index == 0)
            return true;
        return Save.Instance.IsLevelDone(season.levels[index - 1].levelName);
    }
}