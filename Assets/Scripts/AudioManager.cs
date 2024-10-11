using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private const string MusicSaveKey = "MusicSaveKey";
    private const string SoundsSaveKey = "SoundsSaveKey";

    public static AudioManager Instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioSource waterDropSound;

    public float MusicSettings { get; private set; }
    public float SoundsSettings { get; private set; }

    void Awake()
    {
        if (Instance != null) Destroy(Instance);

        Instance = this;
        
        MusicSettings = PlayerPrefs.GetFloat(MusicSaveKey, 0.8f);
        SoundsSettings = PlayerPrefs.GetFloat(SoundsSaveKey, 0.8f);
    }
    private void Start()
    {
        audioMixer.SetFloat("MusicVolume", ParseFloatValueToVolume(MusicSettings));
        audioMixer.SetFloat("SoundsVolume", ParseFloatValueToVolume(SoundsSettings));
    }

    private float ParseFloatValueToVolume(float value)
    {
        return ((value * 100) - 80);
    }

    public void SetMusicVolume(float value)
    {
        MusicSettings = value;
        PlayerPrefs.SetFloat(MusicSaveKey, MusicSettings);
        audioMixer.SetFloat("MusicVolume", ParseFloatValueToVolume(MusicSettings));
    }

    public void SetSoundsVolume(float value)
    {
        SoundsSettings = value;
        PlayerPrefs.SetFloat(SoundsSaveKey, SoundsSettings);
        audioMixer.SetFloat("SoundsVolume", ParseFloatValueToVolume(SoundsSettings));
    }

    public void PlayWaterDropSound()
    {
        waterDropSound.Play();
    }

    public void PlayGameMusic()
    {
        music.clip = gameMusic;
        music.Play();
    }

    public void PlayMenuMusic()
    {
        music.clip = menuMusic;
        music.Play();
    }

    public void PauseGameMusic()
    {
        music.Pause();
    }

    public void ResumeGameMusic()
    {
        music.Play();
    }
}
