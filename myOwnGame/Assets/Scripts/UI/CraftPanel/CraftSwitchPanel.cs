using UnityEngine;

public class CraftSwitchPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] craftPanels;

    public void SwitchPanel(string name)
    {
        foreach (GameObject panel in craftPanels)
        {
            if (panel.gameObject.name != name)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }
}
