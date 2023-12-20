using UnityEngine;

[System.Serializable]
public class MissionWinRow : Mission
{
    public MissionWinRow(MissionData data) : base(data)
    {
    }
    
    public override void Process(int value)
    {
        if (value == 0)
        {
            currentAmount = 0;
            return;
        }
        
        base.Process(value);
    }
}
