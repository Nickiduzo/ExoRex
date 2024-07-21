using UnityEngine;

public class EffectSound : MonoBehaviour
{
    [SerializeField] private string songName;

    private void Start() => AudioManager.Instance.PlaySound(songName);
}
