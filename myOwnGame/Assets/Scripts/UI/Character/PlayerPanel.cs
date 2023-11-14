using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private UserPanel userPanel;
    private void Start()
    {
        if (userPanel != null)
        {
            userPanel.onHideHUD.AddListener(OnHideHud);
            userPanel.onShowHUD.AddListener(OnShowHud);
        }
    }

    private void OnShowHud() => gameObject.SetActive(false);
    private void OnHideHud() => gameObject.SetActive(true);    
}
