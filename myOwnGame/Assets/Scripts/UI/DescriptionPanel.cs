using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionPanel : MonoBehaviour
{
    public static DescriptionPanel Instance;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    public Image ItemIcon { get => itemIcon; set => itemIcon = value; }
    public TextMeshProUGUI ItemName { get => itemName; set => itemName = value; }
    public TextMeshProUGUI ItemDescription { get => itemDescription; set => itemDescription = value; }

}
