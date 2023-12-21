using Homa.Missions.Controllers;
using Homa.Missions.Data;

namespace Homa.Missions.Factory
{
    public interface IMissionsCreator
    {
        Mission Create(MissionData dataSo);
    }
}