using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionsLibrary", menuName = "Missions/Library")]
public class MissionsLibrary : ScriptableObject
{
    [SerializeField]
    private List<MissionData> missions;

    private MissionsCreator missionsCreator = new MissionsCreator();
    
    public Mission GetNewMission(MissionDifficulty difficulty)
    {
        MissionData data = GetRandomMissionData(difficulty);
        return missionsCreator.Create(data);
    }

    private MissionData GetRandomMissionData(MissionDifficulty difficulty)
    {
        List<MissionData> difficultyMissions = missions.Where(x => x.Difficulty == difficulty).ToList();
        return difficultyMissions[Random.Range(0, difficultyMissions.Count)];
    }
}