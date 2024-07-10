using UnityEngine;

[CreateAssetMenu(fileName ="ArenaConfig", menuName ="ArenaConfig")]
public class ArenaConfig : ScriptableObject
{
    public ArenaMode LightMode;
    public ArenaMode MediumMode;
    public ArenaMode HardMode;
    
    public ArenaDifficulty currentDifficulty;
    public ArenaMode currentMode;

    public void ChooseMode(ArenaDifficulty difficult)
    {
        currentDifficulty = difficult;
        switch (difficult)
        {
            case ArenaDifficulty.Light:
                currentMode = LightMode;
                break;
            case ArenaDifficulty.Medium:
                currentMode = MediumMode;
                break;
            case ArenaDifficulty.Hard:
                currentMode = HardMode;
                break;
            default: currentMode = LightMode;
                break;
        }
    }
    public string PrintCurrentMode()
    {
        switch (currentDifficulty)
        {
            case ArenaDifficulty.Light:
                return "Light";
            case ArenaDifficulty.Medium:
                return "Medium";
            case ArenaDifficulty.Hard:
                return "Hard";
        }
        return "NoMode";
    }
}
