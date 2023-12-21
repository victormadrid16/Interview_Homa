using System.Collections.Generic;
using Homa.Missions.Controllers;
using Homa.Missions.Data;
using Homa.Missions.Factory;

public class MissionsCreator : IMissionsCreator
{
    
    private IMissionsFactory defaultFactory = new MissionDefaultFactory();
    private Dictionary<string, IMissionsFactory> factoryTypes = new ()
    {
        { MissionTypes.WinGamesInRow, new MissionWinInRowFactory() },
        { MissionTypes.ReachCombo, new MissionReachComboFactory() },
    };


    public Mission Create(MissionData data)
    {
        if (factoryTypes.TryGetValue(data.Type, out var factory))
        {
            return factory.Create(data);
        }

        return defaultFactory.Create(data);
    }
}
