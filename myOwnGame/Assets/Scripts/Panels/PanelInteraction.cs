using System.Collections.Generic;
using UnityEngine;

public class PanelInteraction : MonoBehaviour
{
    [SerializeField] private List<GameObject> panelObjects;
    [SerializeField] private List<string> panelNames;

    private void Awake()
    {
        gameObject.SetActive(true);
        foreach(Transform child in gameObject.transform)
        {
            panelObjects.Add(child.gameObject);
            panelNames.Add(child.name);
        }
    }

    public void ShowPanel(int panelIndex)
    {
        foreach (var panel in panelObjects)
        {
            panel.SetActive(panel.name == panelNames[panelIndex]);
        }
    }
    public void HideAllPanels()
    {
        foreach (var panel in panelObjects)
        {
            panel.SetActive(false);
        }
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
