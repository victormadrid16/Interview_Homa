using Homa.Missions.Controllers;
using Homa.Missions.Data;
using UnityEngine;

[System.Serializable]
public class MissionWinInRow : Mission
{
    public MissionWinInRow(MissionData data) : base(data)
    {
    }
    
    public override void Process(int value)
    {
        if (value == 0)
        {
            CurrentAmount = 0;
            return;
        }
        
        CurrentAmount = Mathf.Min(CurrentAmount+value, TotalAmount);
    }
}
