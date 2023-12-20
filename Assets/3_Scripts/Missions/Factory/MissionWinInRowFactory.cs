public class MissionWinInRowFactory : IMissionsFactory
{
    public Mission Create(MissionData data)
    {
        return new MissionWinRow(data);
    }
}
