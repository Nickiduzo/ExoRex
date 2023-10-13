using UnityEngine;
using UnityEngine.UI;

public class MineralPanel : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button[] buttons;
    [Header("Line for buttons")]
    [SerializeField] private Image[] lockLine;
    [Header("New button's images")]
    [SerializeField] private Sprite[] newButtonImage;
    [Header("New line's images")]
    [SerializeField] private Sprite[] unlockLine; 

    public void OnClickCharm(string pointerClick)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == pointerClick)
            {
                buttons[i].image.sprite = newButtonImage[i];
                lockLine[i].sprite = unlockLine[i];
            }
        }
    }
}
