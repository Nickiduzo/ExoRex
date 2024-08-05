using TMPro;
using UnityEngine;

public class TalentPanel : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI talentTitle;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI pointsRequired;

    public void SetTalentInfo(Talent talent)
    {
        talentTitle.text = talent.talentName;
        description.text = talent.description;
        pointsRequired.text = $"Points Required: {talent.pointsRequired}";
    }
}
