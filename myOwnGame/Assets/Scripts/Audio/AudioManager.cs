using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject gameObject = new GameObject("Sound" + i + " " + sounds[i].nameSound);

            sounds[i].SetSource(gameObject.AddComponent<AudioSource>());

        }
        PlaySound("Music");
    }

    private void Update()
    {
        if (Time.time > 30f)
        {
            StopSound("Music");
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
}
