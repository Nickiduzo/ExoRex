using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static PointCounter Instanse { get ; private set; }
    
    [SerializeField] private TextMeshProUGUI textPro;
    [SerializeField] private ArenaConfig arenaConfig;

    private static int count;
    private void Start()
    {
        count = 0;
        textPro = GetComponent<TextMeshProUGUI>();
    }
    private void Awake()
    {
        Instanse = this;
    }
    private void Update()
    {
        textPro.text = count.ToString();
    }
    public void UpdateKillCount(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Enemy: count++; 
                break;
            case EnemyType.RexBoss: count += 3;
                break;
        }
    }
    public int ReturnFullScore()
    {
        return count;
    }

    private void OnDisable()
    {
        SetHighScore();
    }
    public void SetHighScore()
    {
        if (count > arenaConfig.highScore)
        {
            arenaConfig.highScore = count;
        }
    }
}
