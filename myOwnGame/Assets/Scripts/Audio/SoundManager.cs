using UnityEngine;

[CreateAssetMenu(fileName ="Sounds", menuName = "ScriptableObjects/Sounds", order = 2)]
public class SoundManager : ScriptableObject
{
    public Sound[] soundsSFX;
    public Sound[] sounds;
}
