using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MineralPanel : MonoBehaviour
{
    [SerializeField] private Button defaultButton;
    [SerializeField] private Button[] mineralButtons;
    [SerializeField] private Image[] lines;

    [SerializeField] private Sprite[] lockedButtonSprites;
    [SerializeField] private Sprite[] unlockedButtonSprites;
    [SerializeField] private Sprite[] lockedLineSprites;
    [SerializeField] private Sprite[] unlockedLineSprites;

    private int previousButtonIndex = -1; 

    private void Start()
    {
        for (int i = 0; i < mineralButtons.Length; i++)
        {
            int buttonIndex = i; 
            mineralButtons[i].onClick.AddListener(() => OnMineralButtonClick(buttonIndex));

            EventTrigger trigger = mineralButtons[i].gameObject.AddComponent<EventTrigger>();
            AddHoverEvents(trigger, buttonIndex);
        }
    }

    private void AddHoverEvents(EventTrigger trigger, int buttonIndex)
    {
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((data) => { OnButtonHoverEnter(buttonIndex); });
        trigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((data) => { OnButtonHoverExit(buttonIndex); });
        trigger.triggers.Add(pointerExit);
    }

    private void OnButtonHoverEnter(int buttonIndex)
    {
        if (previousButtonIndex >= 0)
        {
            mineralButtons[buttonIndex].image.sprite = unlockedButtonSprites[buttonIndex];
        }
    }

    private void OnButtonHoverExit(int buttonIndex)
    {
        if (previousButtonIndex >= 0)
        {
            mineralButtons[buttonIndex].image.sprite = lockedButtonSprites[buttonIndex];
        }
    }

    private void OnMineralButtonClick(int buttonIndex)
    {
        if (previousButtonIndex >= 0)
        {
            lines[buttonIndex].sprite = unlockedLineSprites[buttonIndex];
            mineralButtons[buttonIndex].image.sprite = unlockedButtonSprites[buttonIndex];

            lines[previousButtonIndex].sprite = lockedLineSprites[previousButtonIndex];
            mineralButtons[previousButtonIndex].image.sprite = lockedButtonSprites[previousButtonIndex];
        }

        previousButtonIndex = buttonIndex;
    }
}
