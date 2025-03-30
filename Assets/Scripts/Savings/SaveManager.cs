using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public bool isDishClean;  // Булевое значение для чистоты посуды
}

public class SaveManager : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "savefile.json");
    }

    public void SavePlayerData(Vector3 position, bool isActive, bool isDishClean)
    {
        SaveData data = new SaveData();
        data.playerPosition = position;
        data.isDishClean = isDishClean;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);

        Debug.Log("Game Saved!");
    }

    public SaveData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded!");
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found!");
            return null;
        }
    }
}

