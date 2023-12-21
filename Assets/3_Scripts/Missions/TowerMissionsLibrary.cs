using System.Collections.Generic;
using System.Linq;
using Homa.Missions;
using Homa.Missions.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionsLibrary", menuName = "Missions/Library")]
public class TowerMissionsLibrary : MissionsLibrary
{
    protected override void InitializeMissionsCreator()
    {
        missionsCreator = new MissionsCreator();
    }

    protected override MissionData GetMissionData(MissionDifficulty difficulty)
    {
        List<MissionDataSO> difficultyMissions = missions.Where(x => x.Difficulty == difficulty).ToList();
        if (difficultyMissions.Count == 0)
        {
            Debug.LogWarning($"[{nameof(TowerMissionsLibrary)}] No missions found of difficulty {difficulty}");
            return null;
        }
        return difficultyMissions[Random.Range(0, difficultyMissions.Count)];
        
    }
    
}