using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : MonoBehaviour
{
    [SerializeField] private Token token;
    [SerializeField] private TextMeshProUGUI tokenAmount;

    [SerializeField] private Button easyModeButton;
    [SerializeField] private Button mediumModeButton;
    [SerializeField] private Button hardModeButton;

    private readonly Color availableColor = new Color(129f / 255f, 255f / 255f, 152f / 255f, 180f / 255f); // #81FF98B4
    private readonly Color unavailableColor = new Color(250f / 255f, 125f / 255f, 112f / 255f, 255f / 255f); // #FA7D70FF
    private readonly Color availableHighlightColor = new Color(129f / 255f, 255f / 255f, 152f / 255f, 220f / 255f); // Lighter available color
    private readonly Color unavailableHighlightColor = new Color(250f / 255f, 90f / 255f, 80f / 255f, 255f / 255f);

    private void Start()
    {
        UpdateInterface();
    }

    private void OnEnable()
    {
        UpdateInterface();
    }

    private void UpdateInterface()
    {
        tokenAmount.text = token.amount.ToString();
        UpdateButtonColors();
    }

    private void UpdateButtonColors()
    {
        SetButtonColor(easyModeButton, token.amount >= 1);
        SetButtonColor(mediumModeButton, token.amount >= 2);
        SetButtonColor(hardModeButton, token.amount >= 3);
    }

    private void SetButtonColor(Button button, bool canAfford)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = canAfford ? availableColor : unavailableColor;
        colors.highlightedColor = canAfford ? availableHighlightColor : unavailableHighlightColor;
        button.colors = colors;
    }
}
