namespace Homa.Missions.Data
{
    public class MissionData
    {
        public string Type;
        public int TotalAmount;
        public MissionDifficulty Difficulty;
        public Reward Reward;


        public static implicit operator MissionData(MissionDataSO other)
        {
            return new MissionData
            {
                Type = other.Type,
                TotalAmount = other.TotalAmount,
                Difficulty = other.Difficulty,
                Reward = other.Reward
            };
        }
    }
}