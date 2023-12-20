public class MissionReachComboFactory : IMissionsFactory
{
    public Mission Create(MissionData data)
    {
        return new MissionReachCombo(data);
    }
}