using UnityEngine.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Save
{
    public static Save _instance = null;
    public static Save Instance { set => _instance = value; 
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        } 
    }

    private static readonly string path = Application.persistentDataPath + @"\save.json";

    public static void Load()
    {
        ///////////////////throw new NotImplementedException();
        if (!File.Exists(path))
        {
            Instance = new Save();
            Keep();
        }
        Instance = JsonUtility.FromJson<Save>(File.ReadAllText(path));
    }
    public static void Keep()
    {
        //throw new NotImplementedException();
        File.WriteAllText(path, JsonUtility.ToJson(_instance));
    }

    public HashSet<string> levelDone = new HashSet<string>();
    public int cosmeticArrow = 0;
}
