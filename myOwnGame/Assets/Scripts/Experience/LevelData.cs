using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int maxLevel = 100;
    public int initialXP = 250;
    public float progressionFactor = 2.0f; // Фактор увеличения необходимых очков опыта


    public int currentLevel;
    [HideInInspector] public int currentXP;
    [HideInInspector] public int nextLevelXP;
}
