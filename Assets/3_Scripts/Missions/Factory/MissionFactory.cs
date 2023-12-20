public class MissionFactory : IMissionsFactory
{
    public Mission Create(MissionData data)
    {
        return new Mission(data);
    }
}
