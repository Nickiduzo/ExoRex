using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public SoundManager soundsConfig;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSounds();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSounds()
    {
        for (int i = 0; i < soundsConfig.soundsSFX.Length; i++)
        {
            GameObject soundGameObject = new GameObject("Sound" + i + " " + soundsConfig.soundsSFX[i].nameSound);
            soundGameObject.transform.SetParent(this.transform);
            soundsConfig.soundsSFX[i].SetSource(soundGameObject.AddComponent<AudioSource>());
        }

        for (int j = 0; j < soundsConfig.sounds.Length; j++)
        {
            GameObject soundThemeObject = new GameObject("Sound" + j + " " + soundsConfig.sounds[j].nameSound);
            soundThemeObject.transform.SetParent(this.transform);
            soundsConfig.sounds[j].SetSource(soundThemeObject.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < soundsConfig.soundsSFX.Length; i++)
        {
            if (soundsConfig.soundsSFX[i].nameSound == name)
            {
                soundsConfig.soundsSFX[i].Play();
                return;
            }
        }

        for (int i = 0; i < soundsConfig.sounds.Length; i++)
        {
            if (soundsConfig.sounds[i].nameSound == name)
            {
                soundsConfig.sounds[i].Play();
                return;
            }
        }
    }

    public void StopSound(string name)
    {
        for (int i = 0; i < soundsConfig.soundsSFX.Length; i++)
        {
            if (soundsConfig.soundsSFX[i].nameSound == name)
            {
                soundsConfig.soundsSFX[i].Stop();
                return;
            }
        }

        for (int i = 0; i < soundsConfig.sounds.Length; i++)
        {
            if (soundsConfig.sounds[i].nameSound == name)
            {
                soundsConfig.sounds[i].Stop();
                return;
            }
        }
    }
}
