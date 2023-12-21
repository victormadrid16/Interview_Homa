using UnityEngine;

namespace Homa.Missions.Data
{
    [CreateAssetMenu(fileName = "MissionData", menuName = "Missions/Data")]
    public class MissionDataSO : ScriptableObject
    {
        public string Type;
        public int TotalAmount;
        public MissionDifficulty Difficulty;
        public Reward Reward;
    }
}