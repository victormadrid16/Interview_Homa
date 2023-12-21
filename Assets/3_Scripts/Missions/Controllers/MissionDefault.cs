using Homa.Missions.Controllers;
using Homa.Missions.Data;
using UnityEngine;

[System.Serializable]
public class MissionDefault : Mission
{
    public MissionDefault(MissionData data) : base(data)
    {
    }

    public override void Process(int value)
    {
        CurrentAmount = Mathf.Min(CurrentAmount+value, TotalAmount);
    }
}