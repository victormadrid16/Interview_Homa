using Homa.Missions;
using UnityEngine;

public class TowerMissionsManager : Singleton<TowerMissionsManager>, IMissionsManager
{
    [SerializeField] 
    private int maxMissionsCount = 3;
    [SerializeField]
    private MissionsLibrary missionsLibrary;


    private MissionsManager manager;
    private bool IsEnabled => RemoteConfig.BOOL_MISSIONS_ENABLED;
    
    private void Awake()
    {
        if (!IsEnabled)
        {
            return;
        }

        manager = new MissionsManager();
        manager.Initialize(missionsLibrary, maxMissionsCount);
    }


    public void ProcessMissions(string type, int value)
    {
        if (!IsEnabled)
        {
            return;
        }
        
        manager.ProcessMissions(type,value);
    }
}
