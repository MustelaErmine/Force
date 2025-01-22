using UnityEngine.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

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
        Instance = new Save();
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
    }

    public HashSet<string> levelDoneList = new HashSet<string>();
    public int cosmeticArrow = 1;
    public Dictionary<string, int> stars = new Dictionary<string, int>();
    public HashSet<string> tipsDoneSet = new HashSet<string>();
    public float audioSetting = 1f;
    public bool adfree = false;

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
        Keep();
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
}
