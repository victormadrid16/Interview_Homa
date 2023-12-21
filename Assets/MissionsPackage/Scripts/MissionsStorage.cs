using System.Collections.Generic;
using System.IO;
using Homa.Missions.Controllers;
using UnityEngine;
using Application = UnityEngine.Device.Application;
using Newtonsoft.Json;

namespace Homa.Missions
{
    public class MissionsStorage
    {
        [System.Serializable]
        public class MissionsStorageData
        {
            public List<Mission> Missions;
        }
    
        protected const string FileName = "/missions.data";

        protected JsonSerializerSettings serializationSettings = new JsonSerializerSettings()
            { TypeNameHandling = TypeNameHandling.Auto };
        protected virtual string Path => Application.persistentDataPath + FileName;
    
        public virtual void Save(List<Mission> missions)
        {
            MissionsStorageData data = new MissionsStorageData()
            {
                Missions = missions
            };
            string json = JsonConvert.SerializeObject(data, serializationSettings);

            File.WriteAllText(Path, json);
        }

        public virtual List<Mission> Load()
        {
            if (File.Exists(Path))
            {
                string fileContents = File.ReadAllText(Path);
            
                MissionsStorageData data = JsonConvert.DeserializeObject<MissionsStorageData>(fileContents, serializationSettings);
                if (data.Missions != null)
                {
                    return data.Missions;
                }
                Debug.LogWarning($"[{nameof(MissionsStorage)}] Error loading Missions from {Path} . Loading empty list!");
            }
        
        
            return new List<Mission>();
        }
    }
}