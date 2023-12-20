using System.Collections.Generic;

public class MissionsCreator
{
    
    private IMissionsFactory defaultFactory = new MissionFactory();
    private Dictionary<MissionType, IMissionsFactory> factoryTypes = new Dictionary<MissionType, IMissionsFactory>()
    {
        { MissionType.WinGamesInRow, new MissionWinInRowFactory() },
        { MissionType.ReachCombo, new MissionReachComboFactory() },
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
