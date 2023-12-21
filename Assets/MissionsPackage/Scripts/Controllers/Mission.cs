using Homa.Missions.Data;
using UnityEngine.Serialization;

namespace Homa.Missions.Controllers
{
    [System.Serializable]
    public abstract class Mission
    {
        public int CurrentAmount;
        public MissionData missionData;
        public string Type => missionData.Type;
        public int TotalAmount => missionData.TotalAmount;
        public MissionDifficulty Difficulty => missionData.Difficulty;
        public Reward Reward => missionData.Reward;

        
        public bool IsCompleted => CurrentAmount == missionData.TotalAmount;

        protected Mission(MissionData data)
        {
            missionData = data;
        }

        public abstract void Process(int value);
    }
}