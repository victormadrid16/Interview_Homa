using Homa.Missions.Controllers;
using Homa.Missions.Data;
using Homa.Missions.Factory;

public class MissionDefaultFactory : IMissionsFactory
{
    public Mission Create(MissionData data)
    {
        return new MissionDefault(data);
    }
}
