using System.Collections.Generic;
using Homa.Missions;
using Homa.Missions.Controllers;
using UnityEngine;

public class TowerMissionsManager : Singleton<TowerMissionsManager>, IMissionsManager
{
    [SerializeField] 
    private int maxMissionsCount = 3;
    [SerializeField]
    private MissionsLibrary missionsLibrary;


    private MissionsManager manager;
    public bool IsEnabled => RemoteConfig.BOOL_MISSIONS_ENABLED;
    public int MaxMissionsCount => maxMissionsCount;
    
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
    
    public List<Mission> GetCurrentMissions()
    {
        if (!IsEnabled)
        {
            return null;
        }
        
        return manager.CurrentMissions;
    }
}
