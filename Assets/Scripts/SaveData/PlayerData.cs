using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int[] unlockedLevel;
    [System.Serializable] class SaveData
    {
        public int[] unlockedLevelList;
    }
    const string PLAYER_DATA_FILE_NAME = "PlayerData.data";
    public void Save()
    {
        SaveByJson();
    }
    public void Load()
    {
        LoadFromJson();
    }
    void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }
    void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        LoadData(saveData);
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]
    public static void  DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
#endif
    SaveData SavingData()
    {
        var saveData = new SaveData();
        saveData.unlockedLevelList = unlockedLevel;
        return saveData;
    }
    void LoadData(SaveData saveData)
    {
        unlockedLevel = saveData.unlockedLevelList;
    }
}
