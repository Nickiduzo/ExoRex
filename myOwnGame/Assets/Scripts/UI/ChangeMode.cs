using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    [SerializeField] private ArenaConfig arenaConfig;
    
    private void Update()
    {
        Debug.Log(arenaConfig.PrintCurrentMode());
    }

    public void SetLightMode() => arenaConfig.ChooseMode(ArenaDifficulty.Light);

    public void SetMediumMode() => arenaConfig.ChooseMode(ArenaDifficulty.Medium);

    public void SetHardMode() => arenaConfig.ChooseMode(ArenaDifficulty.Hard);
}
