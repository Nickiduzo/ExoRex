using UnityEngine;

[CreateAssetMenu(fileName ="TalentData", menuName ="ScriptableObjects/TalendData")]
public class TalentData : ScriptableObject
{
    [System.Serializable]
    public class TalentState
    {
        public string talentName;
        public bool isUnlocked;
    }

    public TalentState[] talentStates;

    public bool IsTalentUnlocked(string talentName)
    {
        foreach (var state in talentStates)
        {
            if (state.talentName == talentName)
            {
                return state.isUnlocked;
            }
        }
        return false;
    }

    public void SetTalentUnlocked(string talentName, bool unlocked)
    {
        foreach (var item in talentStates)
        {
            if (item.talentName == talentName)
            {
                item.isUnlocked = unlocked;
                return;
            }
        }
    }
}
