using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    private const string AchievementsSaveKey = "Achievements";

    [SerializeField] private GameManager gameManager;
    [SerializeField] private CharactersSpawner charactersSpawner;

    private Achievements achievements;
    public Achievements Achievements => achievements;

    public int DodgeTheEnemyMaxValue = 100;
    public int StayOneOnTheFieldMaxValue = 20;
    public int Spanded_10_Matches = 10;
    public int Spanded_100_Matches = 100;
    public int Spanded_1000_Matches = 1000;

    void Awake()
    {
        if (PlayerPrefs.HasKey(AchievementsSaveKey))
        {
            achievements = JsonUtility.FromJson<Achievements>(PlayerPrefs.GetString(AchievementsSaveKey));
        }
        else
        {
            achievements = new();
        }
    }

    private void Start()
    {
        gameManager.PlayerWinEvent += AddDodjeTheEnemy;
        charactersSpawner.AllNpcSeedIsDestroyedEvent += AddStayOneOnTheField;

        gameManager.PlayerWinEvent += AddSpandedMatches;
        gameManager.PlayerLostEvent += AddSpandedMatches;
    }

    public void AddDodjeTheEnemy()
    {
        if (achievements.DodgeTheEnemy > DodgeTheEnemyMaxValue) return;
        achievements.DodgeTheEnemy++;
        SaveAchievements();
    }

    public void AddStayOneOnTheField()
    {
        if (achievements.StayOneOnTheField > StayOneOnTheFieldMaxValue) return;
        achievements.StayOneOnTheField++;
        SaveAchievements();
    }
    public void AddSpandedMatches()
    {
        if (achievements.SpandedMatches > Spanded_1000_Matches) return;
        achievements.SpandedMatches++;
        SaveAchievements();
    }


    private void SaveAchievements()
    {
        PlayerPrefs.SetString(AchievementsSaveKey, JsonUtility.ToJson(achievements));
    }
}
