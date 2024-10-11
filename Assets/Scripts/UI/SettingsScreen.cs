using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private Slider soundsSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private Button policyButton;
    [SerializeField] private GameObject policyScreen;

    [SerializeField] private Button backButton;
    [SerializeField] private GameObject mainScreen;

    void Start()
    {
        soundsSlider.value = audioManager.SoundsSettings;
        musicSlider.value = audioManager.MusicSettings;

        soundsSlider.onValueChanged.AddListener(audioManager.SetSoundsVolume);
        musicSlider.onValueChanged.AddListener(audioManager.SetMusicVolume);

        policyButton.onClick.AddListener(OnPolicyButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);

        gameObject.SetActive(false);
    }

    private void OnPolicyButtonClick()
    {
        policyScreen.SetActive(true);
    }

    private void OnBackButtonClick()
    {
        mainScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
