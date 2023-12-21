using System.Collections.Generic;
using Homa.Missions.Controllers;
using Homa.Missions.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionsElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private TextMeshProUGUI difficultyText;
    [SerializeField]
    private TextMeshProUGUI rewardText;
    [SerializeField]
    private TextMeshProUGUI progressText;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private GameObject checkMark;


    private Dictionary<string, string> descriptions = new()
    {
        { MissionTypes.WinGames, "Win {0} games" },
        { MissionTypes.WinGamesInRow, "Win {0} games in a row" },
        { MissionTypes.ReachCombo, "Reach a combo of {0}" },
        { MissionTypes.DestroyBarrels, "Destroy {0} barrels" },
        { MissionTypes.DestroyExplosiveBarrels, "Destroy {0} explosive barrels" }
    };
    
    public void Fill(Mission mission)
    {
        FormatDescription(mission.Type, mission.TotalAmount);
        FormatDifficulty(mission.Difficulty);
        FormatRewards(mission.Reward.Value, mission.Reward.Type);
        FormatProgress(mission.CurrentAmount, mission.TotalAmount);
        CheckCompleted(mission.IsCompleted);
    }

    private void CheckCompleted(bool isCompleted)
    {
        checkMark.gameObject.SetActive(isCompleted);
    }

    private void FormatProgress(int currentAmount, int totalAmount)
    {
        progressText.text = $"{currentAmount}/{totalAmount}";
        progressSlider.value = currentAmount /(float)totalAmount;
    }

    private void FormatRewards(int rewardValue, string rewardType)
    {
        rewardText.text = $"{rewardValue}\n{rewardType}";
    }

    private void FormatDifficulty(MissionDifficulty difficulty)
    {
        difficultyText.text = difficulty.ToString();
    }

    private void FormatDescription(string type, int totalAmount)
    {
        if (!descriptions.TryGetValue(type, out string text))
        {
            Debug.LogWarning($"[{nameof(MissionsElement)}] There is not defined any description for mission of type {type}");
            return;
        } 
        
        descriptionText.text = string.Format(text, totalAmount);
        
    }
}

