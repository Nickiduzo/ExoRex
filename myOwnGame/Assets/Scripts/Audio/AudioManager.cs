using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] sounds;

    private string currentMusic = "Music";
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
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundGameObject = new GameObject("Sound" + i + " " + sounds[i].nameSound);
            soundGameObject.transform.SetParent(this.transform);
            sounds[i].SetSource(soundGameObject.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].nameSound == name)
            {
                sounds[i].Play();
                return;
            }
        }

        //Debug.Log("Don't find sound");
    }

    public void StopSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].nameSound == name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }
    private void ChangeMusicForCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;

        switch (sceneIndex)
        {
            case 0:
                ChangeMusic("MenuMusic");
                break;
            case 1:
                ChangeMusic("ArenaMusic");
                break;
            default:
                ChangeMusic("MenuMusic");
                break;
        }
    }

    private void ChangeMusic(string newMusic)
    {
        StopSound(currentMusic);
        currentMusic = newMusic;
        PlaySound(newMusic);
    }
}
