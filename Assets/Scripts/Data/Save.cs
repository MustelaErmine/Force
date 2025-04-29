#define YG

using UnityEngine.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using PlayablesStudio.Plugins.YandexGamesSDK.Runtime;

[Serializable]
public class Save
{
    public static Save _instance = null;
    public static Save Instance { 
        set => _instance = value; 
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        } 
    }
#if !UNITY_WEBGL
    private static readonly string path = Application.persistentDataPath + @"\save.json";
#endif
    public static void Load()
    {
#if UNITY_WEBGL
#if YG
        YandexGamesSDK.Instance.CloudStorage.Load<Save>("playerSave", (success, data, error) =>
        {
            if (success)
            {
                Debug.Log($"Loaded player data.");
                Instance = data ?? new Save();
            }
            else
            {
                Debug.LogError($"Failed to load player data: {error}");
                Instance = new Save();
            }
        });
#else
        Instance = new Save();
#endif
#else
        if (!File.Exists(path))
        {
            Instance = new Save();
            Keep();
        }
        //Instance = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        Instance = JsonConvert.DeserializeObject<Save>(File.ReadAllText(path));
        //AudioSettings.
        AudioListener.volume = Instance.audioSetting;
#endif
    }
    public static void Keep()
    {
#if !UNITY_WEBGL
        //File.WriteAllText(path, JsonUtility.ToJson(_instance));
        File.WriteAllText(path, JsonConvert.SerializeObject(_instance));
#endif
#if YG
        YandexGamesSDK.Instance.CloudStorage.Save("playerSave", _instance, (success, error) =>
        {
            if (success)
            {
                Debug.Log("Player data saved successfully.");
            }
            else
            {
                Debug.LogError($"Failed to save player data: {error}");
            }
        });
#endif
    }

    public HashSet<string> levelDoneList = new HashSet<string>();
    public int cosmeticArrow = 1;
    public Dictionary<string, int> stars = new Dictionary<string, int>();
    public HashSet<string> tipsDoneSet = new HashSet<string>();
    public float audioSetting = 1f;
    public bool adfree = false;
    public int earnedStars = 0;
    public DateTime starsBoostTime = DateTime.MinValue;
    public LocaledString.Locale locale = LocaledString.Locale.ru_RU;

    public void AddDoneLevel(string level)
    {
        levelDoneList.Add(level);
        Keep();
    }
    public void AddTipsDone(string level)
    {
        tipsDoneSet.Add(level);
        Keep();
    }
    public void ApplyStars(string levelName, int starsCount)
    {
        int oldCount = 0;
        if (stars.ContainsKey(levelName))
            oldCount = stars[levelName];
        stars[levelName] = Mathf.Max(starsCount, oldCount);
        int earnedCount = stars[levelName] - oldCount;
        if ((starsBoostTime - DateTime.Now).TotalMinutes < 5f)
        {
            earnedCount *= 2;
        }
        earnedStars += earnedCount;
        Keep();
        ApplyStarsLeaderboard();
    }
    public bool IsLevelDone(string level) { 
        return levelDoneList.Contains(level);
    }
    public bool IsTipDone(string level) { 
        return tipsDoneSet.Contains(level);
    }
    public int GetStarsCount(string level)
    {
        return stars[level];
    }
    public void ApplyVolume(float value)
    {
        AudioListener.volume = value;
        audioSetting = value;
        Keep();
    }
    public void ApplyStarsLeaderboard()
    {
        YandexGamesSDK.Instance.Leaderboard.SubmitScore("stars", earnedStars);
    }
}
