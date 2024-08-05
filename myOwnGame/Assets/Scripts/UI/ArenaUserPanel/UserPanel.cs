using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserPanel : MonoBehaviour
{
    [SerializeField] private GameObject userHud;
    [SerializeField] private GameObject[] userPanel;
    [SerializeField] private Button[] userButtons;
    [SerializeField] private Sprite[] buttonSprites;

    [SerializeField] private Sprite[] defaultSpriteButtons;

    public UnityEvent onHideHUD = new UnityEvent();
    public UnityEvent onShowHUD = new UnityEvent();

    public string onMouseClick;
    public string onMouseSelect;

    public bool unActivePanel = false;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance;
        if (audioManager == null)
        {
            Debug.Log("No audiomanager found!");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ActivatePanel(0, "Inventory");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            ActivatePanel(1, "Mineral");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            ActivatePanel(2, "Tool");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            ActivatePanel(3, "Implant");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }
    }

    private void ActivatePanel(int buttonIndex, string panelName)
    {
        unActivePanel = true;
        onShowHUD.Invoke();
        DefaultSpriteButton();
        ChangeButtonSprite(buttonIndex);
        SwitchPanel(panelName);
        Time.timeScale = 0; // Останавливаем игру
    }

    private void ClosePanel()
    {
        userHud.SetActive(false);
        unActivePanel = false;
        onHideHUD.Invoke();
        Time.timeScale = 1; // Возобновляем игру
    }

    public void ChangeButtonSprite(int buttonIndex)
    {
        DefaultSpriteButton();
        if (buttonIndex >= 0 && buttonIndex < userButtons.Length)
        {
            userButtons[buttonIndex].image.sprite = buttonSprites[buttonIndex];
        }
    }
    public void SwitchPanel(string panelName)
    {
        userHud.SetActive(true);
        foreach (GameObject panel in userPanel)
        {
            panel.SetActive(panel.name == panelName);
        }
    }
    private void DefaultSpriteButton()
    {
        for (int i = 0; i < userButtons.Length; i++)
            userButtons[i].image.sprite = defaultSpriteButtons[i];
    }

    public void OnMouseClick() => audioManager.PlaySound(onMouseClick);

    public void OnMouseSelect() => audioManager.PlaySound(onMouseSelect);
}
