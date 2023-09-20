using UnityEngine;

public class UserPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] userPanels;

    [SerializeField] private string[] interfaceNames;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            ShowInventory(interfaceNames[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            ShowTool(interfaceNames[1]);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            ShowMineral(interfaceNames[2]);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            ShowImplants(interfaceNames[3]);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) HideAllInterfaces();
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
   
    public void ShowInventory(string interfaceName)
    {
        HideAllInterfaces();
        foreach (var panel in userPanels)
        {
            if (panel.gameObject.name == interfaceName)
            {
                panel.SetActive(true);
            }
        }
    }
    public void ShowImplants(string interfaceName)
    {
        HideAllInterfaces();
        foreach (var panel in userPanels)
        {
            if (panel.gameObject.name == interfaceName)
            {
                panel.SetActive(true);
            }
        }
    }
    public void ShowMineral(string interfaceName)
    {
        HideAllInterfaces();
        foreach (var panel in userPanels)
        {
            if (panel.gameObject.name == interfaceName)
            {
                panel.SetActive(true);
            }
        }
    }
    public void ShowTool(string interfaceName)
    {
        HideAllInterfaces();
        foreach (var panel in userPanels)
        {
            if (panel.gameObject.name == interfaceName)
            {
                panel.SetActive(true);
            }
        }
    }
    private void HideAllInterfaces()
    {
        foreach (var panel in userPanels)
            panel.SetActive(false);
    }
}
