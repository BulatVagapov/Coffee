using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private const string TutorialSaveKey = "Tutorial";
    
    [SerializeField] private GameObject firstScreen;
    [SerializeField] private GameObject secondScreen;
    [SerializeField] private GameObject thirdScreen;
    [SerializeField] private GameObject mainBackground;

    [SerializeField] private MainScreen mainScreen;

    [SerializeField] private Button nextFirstScreenButton;
    [SerializeField] private Button nextSecondScreenButton;
    [SerializeField] private Button okButton;

    private int tutorialProgress;


    void Start()
    {
        tutorialProgress = PlayerPrefs.GetInt(TutorialSaveKey, 0);

        if(tutorialProgress == 1)
        {
            mainScreen.PlayButton.onClick.AddListener(mainScreen.OnPlayButtonClick);
        }
        else
        {
            mainScreen.PlayButton.onClick.AddListener(OpenFirstTutorialScreen);
        }
    }

    private void OpenFirstTutorialScreen()
    {
        mainScreen.gameObject.SetActive(false);
        mainBackground.SetActive(false);
        nextFirstScreenButton.onClick.AddListener(OpenSecondTutorialScreen);
        firstScreen.SetActive(true);
    }

    private void OpenSecondTutorialScreen()
    {
        mainScreen.PlayButton.onClick.RemoveListener(OpenFirstTutorialScreen);
        nextSecondScreenButton.onClick.AddListener(OpenThirdTutorialScreen);

        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
    }

    private void OpenThirdTutorialScreen()
    {
        secondScreen.SetActive(false);
        thirdScreen.SetActive(true);

        okButton.onClick.AddListener(OnOkButtonClick);
    }

    private void OnOkButtonClick()
    {
        tutorialProgress = 1;
        thirdScreen.SetActive(false);

        PlayerPrefs.SetInt(TutorialSaveKey, tutorialProgress);
        mainScreen.PlayButton.onClick.AddListener(mainScreen.OnPlayButtonClick);
        mainBackground.SetActive(true);
        mainScreen.OnPlayButtonClick();
    }
}
