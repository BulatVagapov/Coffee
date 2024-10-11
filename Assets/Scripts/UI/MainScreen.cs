using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button achievementButton;

    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject achievementScreen;
    [SerializeField] private GameObject chooseCharacterScreen;

    [SerializeField] private LoadingScreen loadingScreen;

    public Button PlayButton => playButton;

    void Start()
    {
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        achievementButton.onClick.AddListener(OnAchievementButtonClick);

        loadingScreen.LoadingIsOver += OnLoadingOver;
        gameObject.SetActive(false);
    }

    private void OnLoadingOver()
    {
        gameObject.SetActive(true);
        AudioManager.Instance.PlayMenuMusic();
    }

    private void OnSettingsButtonClick()
    {
        gameObject.SetActive(false);
        settingsScreen.SetActive(true);
    }

    private void OnAchievementButtonClick()
    {
        gameObject.SetActive(false);
        achievementScreen.SetActive(true);
    }

    public void OnPlayButtonClick()
    {
        chooseCharacterScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
