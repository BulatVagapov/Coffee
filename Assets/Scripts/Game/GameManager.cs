using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer Timer { get ; private set;}
    [SerializeField] private CharactersSpawner charactersSpawner;
    [SerializeField] private int gameTimeInSeconds;
    [SerializeField] private GameObject returnerCharactersToPool;
    [SerializeField] private GameObject gameScreen;

    public event Action StartGameEvent;
    public event Action PlayerWinEvent;
    public event Action PlayerLostEvent;


    private void Awake()
    {
        Timer = new Timer();
        Timer.SetTimer(gameTimeInSeconds);
        Timer.TimeOverEvent += OnPlayerWin;
        charactersSpawner.AllNpcSeedIsDestroyedEvent += OnPlayerWin;
        charactersSpawner.PlayerSeed.GetComponent<SeedHealth>().DeadEvent += OnPlayerLost;
    }

    public void StartGame()
    {
        returnerCharactersToPool.SetActive(false);
        charactersSpawner.SpawnGameCharacters();
        Timer.StartTimer();
        gameScreen.SetActive(true);
        StartGameEvent?.Invoke();
        AudioManager.Instance.PlayGameMusic();
    }

    private void OnPlayerWin()
    {
        StopGame();
        PlayerWinEvent?.Invoke();
    }

    private void OnPlayerLost()
    {
        StopGame();
        PlayerLostEvent?.Invoke();
    }

    private void StopGame()
    {
        Timer.StopTimer();
        Time.timeScale = 0;
        AudioManager.Instance.PlayMenuMusic();
    }

    public void PauseGame()
    {
        Timer.TimerPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Timer.TimerPaused = false;
        Time.timeScale = 1;
    }
}
