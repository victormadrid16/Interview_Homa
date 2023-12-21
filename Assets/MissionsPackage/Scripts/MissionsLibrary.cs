using System.Collections.Generic;
using Homa.Missions.Controllers;
using Homa.Missions.Data;
using Homa.Missions.Factory;
using UnityEngine;

namespace Homa.Missions
{
    public abstract class MissionsLibrary : ScriptableObject
    {
        [SerializeField]
        protected List<MissionDataSO> missions;

        protected IMissionsCreator missionsCreator;

        protected virtual void OnEnable()
        {
            InitializeMissionsCreator();
        }

        protected abstract void InitializeMissionsCreator();

        public virtual Mission GetNewMission(MissionDifficulty difficulty)
        {
            MissionData data = GetMissionData(difficulty);
            if (data == null)
            {
                return null;
            }
            return missionsCreator.Create(data);
        }

        protected abstract MissionData GetMissionData(MissionDifficulty difficulty);
    }
}