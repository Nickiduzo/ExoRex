using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public SoundManager soundManager;

    public Slider masterVolumeSlider;
    public Slider soundsVolumeSlider;
    public Slider effectsVolumeSlider;
    public Toggle muteToggle;

    public Sprite toggleOn;
    public Sprite toggleOff;

    private void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        soundsVolumeSlider.onValueChanged.AddListener(SetSoundsVolume);
        effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);
        muteToggle.onValueChanged.AddListener(ToggleMute);

        LoadSettings();
    }

    private void SetMasterVolume(float volume)
    {
        if (!muteToggle.isOn)
        {
            AudioListener.volume = volume / 100;
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }
    }

    private void SetSoundsVolume(float volume)
    {
        foreach (var sound in soundManager.sounds)
        {
            sound.volume = volume / 100;
            if (sound.audioSource != null)
            {
                sound.audioSource.volume = sound.volume;
            }
        }
        PlayerPrefs.SetFloat("SoundsVolume", volume);
    }

    private void SetEffectsVolume(float volume)
    {
        foreach (var sound in soundManager.soundsSFX)
        {
            sound.volume = volume / 100;
            if (sound.audioSource != null)
            {
                sound.audioSource.volume = sound.volume;
            }
        }
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }

    private void ToggleMute(bool isMuted)
    {
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("Mute", isMuted ? 1 : 0);
        if (!isMuted)
        {
            muteToggle.image.sprite = toggleOn;
        }
        else
        {
            muteToggle.image.sprite = toggleOff;
        }
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            masterVolumeSlider.value = masterVolume;
            SetMasterVolume(masterVolume);
        }

        if (PlayerPrefs.HasKey("SoundsVolume"))
        {
            float soundsVolume = PlayerPrefs.GetFloat("SoundsVolume");
            soundsVolumeSlider.value = soundsVolume;
            SetSoundsVolume(soundsVolume);
        }

        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            float effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
            effectsVolumeSlider.value = effectsVolume;
            SetEffectsVolume(effectsVolume);
        }

        if (PlayerPrefs.HasKey("Mute"))
        {
            bool isMuted = PlayerPrefs.GetInt("Mute") == 1;
            muteToggle.isOn = isMuted;
            ToggleMute(isMuted);
        }
    }
}
