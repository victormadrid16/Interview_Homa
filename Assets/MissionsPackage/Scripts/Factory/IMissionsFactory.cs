using Homa.Missions.Controllers;
using Homa.Missions.Data;

namespace Homa.Missions.Factory
{
    public interface IMissionsFactory
    {
        public Mission Create(MissionData data);
    }
}
