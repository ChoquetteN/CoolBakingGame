using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLogOutTime(PlayerData pd)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Storedata.Spooky";
        Debug.Log("Saving data to" + path);
        FileStream stream = new FileStream(path, FileMode.Create);
        DateTime saveTime = DateTime.Now;
        PlayerData data = new PlayerData(saveTime.Month, saveTime.Day, saveTime.Hour, saveTime.Minute, pd.Gold, pd.storeItems);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayerData()
    {
        string path = Application.persistentDataPath + "/Storedata.Spooky";
        Debug.Log("Drawing data from " + path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
