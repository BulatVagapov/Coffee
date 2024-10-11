using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CharactersSpawner charactersSpawner;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text currentQuantityofNpcSeedsText;
    [SerializeField] private TMP_Text maxQuantityofNpcSeedsText;
    [SerializeField] private Button pauseButton;
    [SerializeField] private PlayerHealthView playerHealthView;
    [SerializeField] private GameObject pauseScreen;


    void Start()
    {
        maxQuantityofNpcSeedsText.text = charactersSpawner.NpcSeedsQuantity.ToString();
        currentQuantityofNpcSeedsText.text = charactersSpawner.NpcSeedsQuantity.ToString();

        charactersSpawner.CurrentNumberOfSeedsChengedEvent += (value) => currentQuantityofNpcSeedsText.text = value.ToString();
        gameManager.Timer.TimeChengedEvent += (value) => timerText.text = (value / 60) + ":" + ((value % 60) < 10 ? "0" + (value % 60) : (value % 60));

        gameManager.StartGameEvent += playerHealthView.RefillHearts;

        charactersSpawner.PlayerSeed.GetComponent<SeedHealth>().HealthPointChangedEvent += OnPlayerSeedHealthChanged;

        pauseButton.onClick.AddListener(OnPauseButtonClick);

        gameObject.SetActive(false);
    }

    private void OnPlayerSeedHealthChanged()
    {
        playerHealthView.EmptyHeart();
    }

    private void OnPauseButtonClick()
    {
        pauseScreen.SetActive(true);
        gameManager.PauseGame();
        AudioManager.Instance.PauseGameMusic();
    }
}
