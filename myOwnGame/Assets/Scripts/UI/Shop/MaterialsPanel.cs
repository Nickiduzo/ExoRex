using UnityEngine;
using UnityEngine.UI;

public class MaterialsPanel : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform content;
    [SerializeField] private float scrollStep = 200f; // Adjust this to match your content size

    private float contentWidth;
    private float viewportWidth;
    private float currentPosition = 0f;

    private void Start()
    {
        contentWidth = content.rect.width;
        viewportWidth = scrollRect.viewport.rect.width;
        UpdateButtons();

        previousButton.onClick.AddListener(OnPreviousButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    private void OnPreviousButtonClicked()
    {
        currentPosition -= scrollStep;
        if (currentPosition < 0) currentPosition = 0;

        SetScrollPosition(currentPosition);
        UpdateButtons();
    }

    private void OnNextButtonClicked()
    {
        currentPosition += scrollStep;
        if (currentPosition > contentWidth - viewportWidth)
            currentPosition = contentWidth - viewportWidth;

        SetScrollPosition(currentPosition);
        UpdateButtons();
    }

    private void SetScrollPosition(float position)
    {
        float normalizedPosition = position / (contentWidth - viewportWidth);
        scrollRect.horizontalNormalizedPosition = normalizedPosition;
    }

    private void UpdateButtons()
    {
        previousButton.gameObject.SetActive(currentPosition > 0);
        nextButton.gameObject.SetActive(currentPosition < contentWidth - viewportWidth);
    }
}
