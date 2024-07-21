using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    public LevelData levelData;
    public Slider experienceSlider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expAmount;

    private int currentLevel = 1;
    private int currentXP = 0;
    private int nextLevelXP;

    private void Start()
    {
        instance = this;
        currentLevel = levelData.currentLevel;
        currentXP = levelData.currentXP;
        nextLevelXP = levelData.nextLevelXP;
        UpdateLevelUI();
    }

    private void OnEnable()
    {
        AudioManager.Instance.PlaySound("ArenaMusic");
        AudioManager.Instance.StopSound("MenuMusic");
    }
    private void OnDisable()
    {
        AudioManager.Instance.StopSound("ArenaMusic");
        levelData.currentLevel = currentLevel;
        levelData.nextLevelXP = nextLevelXP;
        levelData.currentXP = currentXP;
    }
    public void AddExperience(int amount)
    {
        currentXP += amount;
        while (currentXP >= nextLevelXP && currentLevel < levelData.maxLevel)
        {
            currentXP -= nextLevelXP;
            currentLevel++;
            nextLevelXP = CalculateNextLevelXP(currentLevel);
        }
        UpdateLevelUI();
    }

    private int CalculateNextLevelXP(int level)
    {
        return (int)(levelData.initialXP * Mathf.Pow(levelData.progressionFactor, level - 1));
    }

    private void UpdateLevelUI()
    {
        expAmount.text = currentXP + "/" + nextLevelXP.ToString();
        nextLevelXP = CalculateNextLevelXP(currentLevel);
        experienceSlider.maxValue = nextLevelXP;
        experienceSlider.value = currentXP;
        levelText.text = currentLevel.ToString();
    }
}
