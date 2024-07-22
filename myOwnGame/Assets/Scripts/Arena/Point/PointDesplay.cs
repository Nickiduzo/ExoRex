using TMPro;
using UnityEngine;

public class PointDesplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTitle;
    [SerializeField] private ArenaConfig arenaConfig;

    public ArenaDifficulty difficulty;

    private void OnEnable()
    {
        switch (difficulty)
        {
            case ArenaDifficulty.Light:
                scoreTitle.text = arenaConfig.LightMode.highScore.ToString();
                break;
            case ArenaDifficulty.Medium:
                scoreTitle.text = arenaConfig.MediumMode.highScore.ToString();
                break;
            case ArenaDifficulty.Hard:
                scoreTitle.text = arenaConfig.HardMode.highScore.ToString();
                break;
            default:
                Debug.Log("Get lost difficulty");
                break;
        }
    }
}
