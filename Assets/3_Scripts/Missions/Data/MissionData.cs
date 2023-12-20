using UnityEngine;


[CreateAssetMenu(fileName = "MissionData", menuName = "Missions/Data")]
public class MissionData : ScriptableObject
{
    public MissionType Type;
    public int TotalAmount;
    public MissionDifficulty Difficulty;
    public Reward Reward;
}