using System.Collections.Generic;
using UnityEngine;

public class PanelInteraction : MonoBehaviour
{
    public static PanelInteraction Instance;
    [SerializeField] private DescriptionPanel descriptionPanel;
    [SerializeField] private GameObject hidableArea;
    [SerializeField] private GameObject parentPanel;
    [SerializeField] private List<GameObject> panelObjects;
    [SerializeField] private List<string> panelNames;

    public DescriptionPanel DescriptionPanel => descriptionPanel;

    private void Awake()
    {
        Instance = this;
        descriptionPanel = GetComponentInChildren<DescriptionPanel>();
        gameObject.SetActive(true);
        hidableArea.SetActive(false);
        foreach (Transform child in parentPanel.transform)
        {
            panelObjects.Add(child.gameObject);
            panelNames.Add(child.name);
        }
    }
    public void ShowPanel(int panelIndex)
    {
        hidableArea.SetActive(true);
        foreach (var panel in panelObjects)
        {
            panel.SetActive(panel.name == panelNames[panelIndex]);
        }
    }
    public void HideAll()
    {
        hidableArea.SetActive(false);
    }

    public void InventoryButton()
    {

    }
    public void PointerSelectButton(string soundName)
    {
        // Play select sound for button
    }

    public void PointerClickSound(string soundName)
    {
        // Play click sound for button
    }
    // Charm - is element, which player or user can click and improve base stats or stats of player
    public void PointerSelectCharm()
    {
        DoneSelectCharm();
    }
    private void DoneSelectCharm()
    {
        // Play select charm 
    }
}
