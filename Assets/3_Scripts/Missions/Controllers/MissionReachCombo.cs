using Homa.Missions.Controllers;
using Homa.Missions.Data;
using UnityEngine;

[System.Serializable]
public class MissionReachCombo : Mission
{
    public MissionReachCombo(MissionData data) : base(data)
    {
    }

    public override void Process(int value)
    {
        if (IsCompleted)
        {
            return;
        }
        
        CurrentAmount = Mathf.Min(value, TotalAmount);
    }
}