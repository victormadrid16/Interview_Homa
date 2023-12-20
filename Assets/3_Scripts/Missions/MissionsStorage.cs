using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Application = UnityEngine.Device.Application;

public class MissionsStorage
{
    [System.Serializable]
    public class MissionsStorageData
    {
        public List<Mission> Missions;
    }
    
    private const string FileName = "/missions.data";

    private string Path => Application.persistentDataPath + FileName;
    
    public void Save(List<Mission> missions)
    {
        MissionsStorageData data = new MissionsStorageData()
        {
            Missions = missions
        };
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Path, json);
    }

    public List<Mission> Load()
    {
        if (File.Exists(Path))
        {
            string fileContents = File.ReadAllText(Path);
            
            MissionsStorageData data = JsonUtility.FromJson<MissionsStorageData>(fileContents);
            return data.Missions;
        }
        
        
        return new List<Mission>();
    }
}