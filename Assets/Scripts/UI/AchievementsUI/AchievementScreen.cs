using UnityEngine;
using UnityEngine.UI;

public class AchievementScreen : MonoBehaviour
{
    [SerializeField] private AchievementGroup[] achievementGroups;
    [SerializeField] private AchievementsManager achievementsManager;

    [SerializeField] private Button backButton;
    [SerializeField] private GameObject mainScreen;

    private int current_100_Value;
    private int current_10_Value;

    private void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClick);
        gameObject.SetActive(false);
    }

    private void SetAchievementGroupsView()
    {
        achievementGroups[0].SetAchievementGroupView(achievementsManager.Achievements.DodgeTheEnemy, achievementsManager.DodgeTheEnemyMaxValue);
        achievementGroups[1].SetAchievementGroupView(achievementsManager.Achievements.StayOneOnTheField, achievementsManager.StayOneOnTheFieldMaxValue);
        achievementGroups[2].SetAchievementGroupView(achievementsManager.Achievements.SpandedMatches, achievementsManager.Spanded_1000_Matches);

        current_100_Value = Mathf.Clamp(achievementsManager.Achievements.SpandedMatches, 0, achievementsManager.Spanded_100_Matches);
        achievementGroups[3].SetAchievementGroupView(current_100_Value, achievementsManager.Spanded_100_Matches);

        current_10_Value = Mathf.Clamp(achievementsManager.Achievements.SpandedMatches, 0, achievementsManager.Spanded_10_Matches);
        achievementGroups[4].SetAchievementGroupView(current_10_Value, achievementsManager.Spanded_10_Matches);
    }

    private void OnEnable()
    {
        if (achievementsManager == null || achievementsManager.Achievements == null) return;

        SetAchievementGroupsView();
    }

    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        mainScreen.SetActive(true);
    }
}
