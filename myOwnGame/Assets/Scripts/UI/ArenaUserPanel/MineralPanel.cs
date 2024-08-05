using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MineralPanel : MonoBehaviour
{
    [Header("Talent UI")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private Image[] lockLine;
    [SerializeField] private Sprite[] newButtonImage;
    [SerializeField] private Sprite[] unlockLine;

    [SerializeField] private GameObject talentInfoPrefab;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private Talent[] talents;
    [SerializeField] private LevelData levelData;
    [SerializeField] private TalentData talentData;

    [SerializeField] private TextMeshProUGUI avaiblePoints;
    
    private float xPos = 0.4f;
    private float yPos = 0.2f;

    private GameObject currentTalent;
    private bool[] talentsUnlocked;

    private void Start()
    {
        talentsUnlocked = new bool[buttons.Length];
        talentsUnlocked[0] = true; // Первый талант открыт по умолчанию
        UpdateButtonsAndLines();
        UpdateAvaiblePointsUI();
        InitializeTalants();
    }

    public void OnClickCharm(string pointerClick)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == pointerClick && talentsUnlocked[i])
            {
                if (levelData.avaiblePoints >= talents[i].pointsRequired) // Проверяем, хватает ли очков
                {
                    SpendPoints(talents[i].pointsRequired); // Тратим очки

                    buttons[i].image.sprite = newButtonImage[i];
                    if (i < lockLine.Length) lockLine[i].sprite = unlockLine[i];

                    if (i + 1 < talentsUnlocked.Length)
                    {
                        talentsUnlocked[i + 1] = true; // Открываем следующий талант
                    }

                    talentData.SetTalentUnlocked(talents[i].talentName, true);
                    UpdateButtonsAndLines();
                }
                else
                {
                    Debug.Log("Недостаточно очков для разблокировки таланта!");
                }
            }
        }
    }
    private void OnEnable()
    {
        UpdateAvaiblePointsUI();
    }

    private void InitializeTalants()
    {
        for (int i = 0; i < talentData.talentStates.Length; i++)
        {
            talentsUnlocked[i] = talentData.talentStates[i].isUnlocked;
        }
        UpdateButtonsAndLines();
    }
    private void UpdateButtonsAndLines()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = talentsUnlocked[i];
        }
    }

    private void UpdateAvaiblePointsUI()
    {
        avaiblePoints.text = "Avaible Points: " + levelData.avaiblePoints; 
    }

    private void SpendPoints(int points)
    {
        levelData.avaiblePoints -= points;
        UpdateAvaiblePointsUI();
    }
    private void OnDisable()
    {
        Destroy(currentTalent);
    }
    public void OnPointerEnterTalent(int index)
    {
        if (currentTalent != null)
        {
            Destroy(currentTalent);
        }
            
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x + 100, mousePosition.y, mainCamera.nearClipPlane));
        worldPosition.z = 0;

        worldPosition.x += xPos;
        worldPosition.y += yPos;

        currentTalent = Instantiate(talentInfoPrefab, worldPosition, Quaternion.identity, transform);
        TalentPanel talentInfoPanel = currentTalent.GetComponent<TalentPanel>();

        Talent talent = talents[index];
        talentInfoPanel.SetTalentInfo(talent);
        
    }

    public void OnPointerExitTalent()
    {
        if (currentTalent != null)
        {
            Destroy(currentTalent);
        }
    }
}
