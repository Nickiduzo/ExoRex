using TMPro;
using UnityEngine;

public class PointDesplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTitle;
    [SerializeField] private ArenaConfig arenaConfig;
    
    private void OnEnable()
    {
        scoreTitle.text += arenaConfig.highScore.ToString();
    }
}
