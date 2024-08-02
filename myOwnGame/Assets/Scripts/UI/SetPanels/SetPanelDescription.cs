using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPanelDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI stuffName;
    [SerializeField] private Image stuffPicture;

    public void UpdateDescription(string name, string desc, Sprite image)
    {
        stuffName.text = name;
        description.text = TextFormater.FormatDescription(desc);
        stuffPicture.sprite = image;
        stuffPicture.preserveAspect = true;
    }
}
