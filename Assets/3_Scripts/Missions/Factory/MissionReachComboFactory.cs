﻿using Homa.Missions.Controllers;
using Homa.Missions.Data;
using Homa.Missions.Factory;

public class MissionReachComboFactory : IMissionsFactory
{
    public Mission Create(MissionData data)
    {
        return new MissionReachCombo(data);
    }
}