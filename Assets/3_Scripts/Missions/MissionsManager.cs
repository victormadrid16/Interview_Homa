using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionsManager : Singleton<MissionsManager>
{
    [SerializeField] 
    private int maxMissionsCount = 3;
    [SerializeField]
    private MissionsLibrary missionsLibrary;

    private List<Mission> currentMissions;
    private MissionsStorage storage;

    private bool IsEnabled => RemoteConfig.BOOL_MISSIONS_ENABLED;


    private void Awake()
    {
        if (!IsEnabled)
        {
            return;
        }
        
        Initialize();
    }

    private void Initialize()
    {
        storage = new MissionsStorage();

        currentMissions = LoadMissions();
        
        CheckNoMoreMissions();
    }
    
    private void CheckNoMoreMissions()
    {
        if (currentMissions.Count == 0)
        {
            AddNewMissions();
        }
    }

    private void AddNewMissions()
    {
        for (int i = 0; i < maxMissionsCount; i++)
        {
            MissionDifficulty difficulty = (MissionDifficulty)i;
            Mission mission = missionsLibrary.GetNewMission(difficulty);
            currentMissions.Add(mission);
            Debug.Log($"Added new mission {mission.missionData.name}");
        }
        SaveMissions();
    }

    public void ProcessMissions(MissionType type, int value)
    {
        if (!IsEnabled)
        {
            return;
        }
        
        List<Mission> processMissions = currentMissions.Where(x => x.Type == type).ToList();
        if (processMissions.Count > 0)
        {
            processMissions.ForEach(x => x.Process(value));
            SaveMissions();
        }
    }
    
    private void SaveMissions()
    {
        storage.Save(currentMissions);
    }
    
    private List<Mission> LoadMissions()
    {
        return storage.Load();
    }
}