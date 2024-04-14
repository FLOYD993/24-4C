using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveByJson(string SaveFileName, object data)
    {
        var json = JsonUtility.ToJson(data); //将data转为json
        var path = Path.Combine(Application.persistentDataPath, SaveFileName); //需要写入的文件路径，如果文件已经存在，就会直接覆盖
        //Application是一个永久保存数据的方法，可以根据不同平台（windows/安卓等）自动变更文件格式
        
        try
        {
            File.WriteAllText(path, json); //将json文件写入一个文本文件中
            Debug.Log($"Successfully saved data to {path}.");
        }
        catch(System.Exception ex)
        {
            Debug.Log($"Failed to save data to {path}.");
        }
    }
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine (Application.persistentDataPath, saveFileName);
       
        try
        {
            var json = File.ReadAllText(saveFileName);
            var data = JsonUtility.FromJson<T>(json);

            return data;
        }
        catch (System.Exception ex)
        {
            Debug.Log($"Failed to load data from {path}.");
            return default;
        }
    }
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        
        try
        {
            File.Delete(path);
        }
        catch (System.Exception ex)
        {
            Debug.Log($"Failed to delete data from {path}.");
        }
    }
}
