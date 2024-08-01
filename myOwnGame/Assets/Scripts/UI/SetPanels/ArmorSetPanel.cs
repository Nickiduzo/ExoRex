using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmorSetPanel : MonoBehaviour
{
    [SerializeField] private GameObject oneArmor;

    [SerializeField] private Transform armorOverview;
    [SerializeField] private Stuff stuff;

    private List<GameObject> armorGalary = new List<GameObject>();

    private void Start()
    {
        InitializeOneArmor();
    }
    public void SetArmor()
    {

    }

    private void InitializeOverview()
    {

    }

    private void InitializeOneArmor()
    {
        for (int i = 0; i < stuff.armor.Count; i++)
        {
            GameObject newButton = Instantiate(oneArmor, armorOverview);

            var armorButtonTitle = newButton.transform.Find("StuffTitle").GetComponent<TextMeshProUGUI>();
            var armorButtonImage = newButton.transform.Find("ArmorImage").GetComponent<Image>();

            armorButtonTitle.text = stuff.armor[i].armorName.ToString();
            armorButtonImage.sprite = stuff.armor[i].armorImage;
            armorGalary.Add(newButton);
        }
    }
}
