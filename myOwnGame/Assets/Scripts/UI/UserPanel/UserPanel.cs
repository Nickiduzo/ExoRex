using UnityEngine;
using UnityEngine.UI;

public class UserPanel : MonoBehaviour
{
    [SerializeField] private GameObject userHud;
    [SerializeField] private GameObject[] userPanel;
    [SerializeField] private Button[] userButtons;
    [SerializeField] private Sprite[] buttonSprites;

    [SerializeField] private Sprite[] defaultSpriteButtons;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            DefaultSpriteButton();
            ChangeButtonSprite(0);
            SwitchPanel("Inventory");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            DefaultSpriteButton();
            ChangeButtonSprite(1);
            SwitchPanel("Mineral");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            DefaultSpriteButton();
            ChangeButtonSprite(2);
            SwitchPanel("Tool");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            DefaultSpriteButton();
            ChangeButtonSprite(3);
            SwitchPanel("Implant");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            userHud.SetActive(false);
        }
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
        for(int i = 0; i < userButtons.Length;i++)
            userButtons[i].image.sprite = defaultSpriteButtons[i];
    }
}
