using System;
using UnityEngine;

[Serializable]
public class Panel : MonoBehaviour
{
    public string panelString;

    public void ShowElement()
    {
        gameObject.SetActive(true);
    }
    public void HideElement()
    {
        gameObject.SetActive(false);
    }

}
