using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;

    [SerializeField] private Transform overview;
    [SerializeField] private Stuff stuff;
    [SerializeField] private string nameOfLabaratory;
    [SerializeField] private SetPanelDescription setPanelDescription;

    private List<GameObject> galary = new List<GameObject>();

    private void Start()
    {
        InitializeOverview();
        ShowFirstItem();
    }

    private void InitializeOverview()
    {
        switch (nameOfLabaratory)
        {
            case "Armor":
                InitializeItems(stuff.armor, item => item.armorName, item => item.armorImage, item => item.description);
                break;
            case "Implant":
                InitializeItems(stuff.labaratory, item => item.implantName, item => item.implantImage, item => item.description);
                break;
            case "Wheapon":
                InitializeItems(stuff.arsenal, item => item.wheaponName, item => item.wheaponImage, item => item.description);
                break;
            default:
                InitializeItems(stuff.armor, item => item.armorName, item => item.armorImage, item => item.description);
                break;
        }
    }

    private void InitializeItems<T>(List<T> items, System.Func<T, string> getName, System.Func<T, Sprite> getImage, System.Func<T, string> getDescription)
    {
        foreach (var item in items)
        {
            GameObject newButton = Instantiate(buttonPrefab, overview);
            var buttonTitle = newButton.transform.Find("StuffTitle").GetComponent<TextMeshProUGUI>();
            var buttonImage = newButton.transform.Find("Picture").GetComponent<Image>();

            buttonTitle.text = getName(item);
            buttonImage.sprite = getImage(item);


            newButton.GetComponent<Button>().onClick.AddListener(() => setPanelDescription.UpdateDescription(getName(item), getDescription(item), getImage(item)));
            galary.Add(newButton);
        }
    }

    private void ShowFirstItem()
    {
        if (galary.Count > 0 )
        {
            galary[0].GetComponent<Button>().onClick.Invoke();
        }
    }
}