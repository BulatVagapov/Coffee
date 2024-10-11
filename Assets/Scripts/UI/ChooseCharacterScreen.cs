using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterScreen : MonoBehaviour
{
    [SerializeField] PlayerCharacterViewSetter playerCharacterViewSetter;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject MainBackground;

    [SerializeField] private Button bigEyesButton;
    [SerializeField] private Button pinkCheeksButton;
    [SerializeField] private Button glassesButton;

    [SerializeField] private Sprite bigEyesChoosen;
    [SerializeField] private Sprite bigEyesUnChoosen;

    [SerializeField] private Sprite pinkCheeksChoosen;
    [SerializeField] private Sprite pinkCheeksUnChoosen;

    [SerializeField] private Sprite glassesChoosen;
    [SerializeField] private Sprite glassesUnChoosen;

    private Image bigEyesButtonImage;
    private Image pinkCheeksButtonImage;
    private Image glassesButtonImage;


    [SerializeField] private Button okButton;


    void Start()
    {
        bigEyesButtonImage = bigEyesButton.GetComponent<Image>();
        pinkCheeksButtonImage = pinkCheeksButton.GetComponent<Image>();
        glassesButtonImage = glassesButton.GetComponent<Image>();


        bigEyesButton.onClick.AddListener(OnBigEyesButtonClick);
        pinkCheeksButton.onClick.AddListener(OnPinkCheeksButtonClick);
        glassesButton.onClick.AddListener(OnGlassesButtonClick);
        okButton.onClick.AddListener(OnOkButtonClick);
        OnBigEyesButtonClick();

        gameObject.SetActive(false);
    }

    private void OnOkButtonClick()
    {
        gameManager.StartGame();
        gameObject.SetActive(false);
        MainBackground.SetActive(false);
    }

    private void OnBigEyesButtonClick()
    {
        playerCharacterViewSetter.SetPlayerCharacterView(0);

        bigEyesButtonImage.sprite = bigEyesChoosen;
        pinkCheeksButtonImage.sprite = pinkCheeksUnChoosen;
        glassesButtonImage.sprite = glassesUnChoosen;
    }

    private void OnPinkCheeksButtonClick()
    {
        playerCharacterViewSetter.SetPlayerCharacterView(1);

        bigEyesButtonImage.sprite = bigEyesUnChoosen;
        pinkCheeksButtonImage.sprite = pinkCheeksChoosen;
        glassesButtonImage.sprite = glassesUnChoosen;
    }

    private void OnGlassesButtonClick()
    {
        playerCharacterViewSetter.SetPlayerCharacterView(2);

        bigEyesButtonImage.sprite = bigEyesUnChoosen;
        pinkCheeksButtonImage.sprite = pinkCheeksUnChoosen;
        glassesButtonImage.sprite = glassesChoosen;
    }
}
