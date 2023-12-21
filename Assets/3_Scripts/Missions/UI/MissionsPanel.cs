using System;
using System.Collections;
using System.Collections.Generic;
using Homa.Missions.Controllers;
using UnityEngine;

public class MissionsPanel : MonoBehaviour
{
    [SerializeField] 
    private MissionsElement missionsElementPrefab;
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private Transform missionsParent;
    [SerializeField]
    private GameObject button;

    private List<MissionsElement> missions;

    private void Awake()
    {
        if (!TowerMissionsManager.Instance.IsEnabled)
        {
            HideButton();
            return;
        }
        
        var missionsCount = TowerMissionsManager.Instance.MaxMissionsCount;
        CreateMissions(missionsCount);
    }
    
    public void HideButton()
    {
        button.SetActive(false);
    }
    
    public void ShowContainer()
    {
        container.SetActive(true);
        FillMissions();
    }
    
    public void HideContainer()
    {
        container.SetActive(false);
    }
    
    private void CreateMissions(int count)
    {
        missions = new List<MissionsElement>();
        for (int i = 0; i < count; i++)
        {
            MissionsElement element = Instantiate(missionsElementPrefab, missionsParent);
            missions.Add(element);
        }
    }
    
    private void FillMissions()
    {
        List<Mission> currentMissions = TowerMissionsManager.Instance.GetCurrentMissions();
        int count = missions.Count;
        for (int i = 0; i < count; i++)
        {
            missions[i].Fill(currentMissions[i]);
        }
    }
}
