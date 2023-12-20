using UnityEngine;

[System.Serializable]
public class Mission
{
    protected int currentAmount;
    public MissionData missionData;
    
    public MissionType Type => missionData.Type;
    public int TotalAmount => missionData.TotalAmount;
    public MissionDifficulty Difficulty => missionData.Difficulty;
    public Reward Reward => missionData.Reward;
    
    public int CurrentAmount => currentAmount;
    public bool IsCompleted => currentAmount == missionData.TotalAmount;

    public Mission(MissionData data)
    {
        missionData = data;
    }
    
    public virtual void Process(int value)
    {
        currentAmount = Mathf.Max(currentAmount + value, TotalAmount);
    }
}