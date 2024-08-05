using UnityEngine;

[CreateAssetMenu(fileName ="Talent", menuName ="Talents/Talent")]
public class Talent : ScriptableObject
{
    public string talentName;
    public string description;
    public int requiredLevel;
    public int pointsRequired;
}
