using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static readonly string saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");

    public static SaveData data { get; private set; } = new SaveData();



    public static void Save()
    {
        string json = JsonUtility.ToJson(data);


        File.WriteAllText(saveFilePath, json);
        Debug.Log(saveFilePath);

    }

    public static void Load()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);

            data = JsonUtility.FromJson<SaveData>(json);
            data = null;
        }
    }
}

[System.Serializable]
public class SaveData
{
    [SerializeField] private int maxlevel = 1;
    public int MaxLevel
    {
        get 
        {
            SaveManager.Load();
            return maxlevel; 
        }

        set
        {
            maxlevel = System.Math.Clamp(value, 0, 18);
            SaveManager.Save();
        }
    }
}
