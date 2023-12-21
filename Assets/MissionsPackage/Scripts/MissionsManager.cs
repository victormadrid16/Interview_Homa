using System.Collections.Generic;
using System.Linq;
using Homa.Missions.Controllers;
using Homa.Missions.Data;

namespace Homa.Missions
{
    public class MissionsManager : IMissionsManager
    {
        protected int maxMissionsCount;
        protected MissionsLibrary missionsLibrary;

        protected List<Mission> currentMissions;
        protected MissionsStorage storage;
    
        public virtual void Initialize(MissionsLibrary library, int maxMissions)
        {
            missionsLibrary = library;
            maxMissionsCount = maxMissions;
        
            InitializeStorage();

            currentMissions = LoadMissions();
        
            CheckNoMoreMissions();
        }

        protected virtual void InitializeStorage()
        {
            storage = new MissionsStorage();
        }

        protected virtual void CheckNoMoreMissions()
        {
            if (currentMissions.Count == 0)
            {
                AddNewMissions();
            }
        }

        protected virtual void AddNewMissions()
        {
            for (int i = 0; i < maxMissionsCount; i++)
            {
                MissionDifficulty difficulty = (MissionDifficulty)i;
                AddMissionDifficulty(difficulty);
            }
            SaveMissions();
        }

        protected virtual void AddMissionDifficulty(MissionDifficulty difficulty)
        {
            Mission mission = missionsLibrary.GetNewMission(difficulty);
            if (mission != null)
            {
                currentMissions.Add(mission);
            }
        }

        public virtual void ProcessMissions(string type, int value)
        {
        
            List<Mission> processMissions = currentMissions.Where(x => x.Type == type).ToList();
            if (processMissions.Count > 0)
            {
                processMissions.ForEach(x => x.Process(value));
                SaveMissions();
            }
        }
    
        protected virtual void SaveMissions()
        {
            storage.Save(currentMissions);
        }
    
        protected virtual List<Mission> LoadMissions()
        {
            return storage.Load();
        }
    }
}