using Homa.Missions.Controllers;
using Homa.Missions.Data;
using Homa.Missions.Factory;

public class MissionWinInRowFactory : IMissionsFactory
{
    public Mission Create(MissionData data)
    {
        return new MissionWinInRow(data);
    }
}
