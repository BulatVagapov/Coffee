using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameProvider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject endOfGameScreen;
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject mainBackground;
    [SerializeField] private Button okButton;
    [SerializeField] private TMP_Text gameResultText;
    [SerializeField] private GameObject returnerCharactersToPool;

    private string winString = "You win!";
    private string lostString = "You lost!";

    private void Start()
    {
        okButton.onClick.AddListener(onOkButtonClick);
        gameManager.PlayerWinEvent += OnPlayerWin;
        gameManager.PlayerLostEvent += OnPlayerLost;

        endOfGameScreen.SetActive(false);
    }

    private void onOkButtonClick()
    {
        returnerCharactersToPool.SetActive(true);
        Time.timeScale = 1;
        mainScreen.SetActive(true);
        mainBackground.SetActive(true);
        endOfGameScreen.SetActive(false);
    }

    private void OnPlayerWin()
    {
        gameResultText.text = winString;
        endOfGameScreen.SetActive(true);
    }

    private void OnPlayerLost()
    {
        gameResultText.text = lostString;
        endOfGameScreen.SetActive(true);
    }
}
