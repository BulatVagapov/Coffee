using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private GameManager gameManager;


    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClick);
        gameObject.SetActive(false);
    }

    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        gameManager.ResumeGame();
        AudioManager.Instance.ResumeGameMusic();
    }
}
