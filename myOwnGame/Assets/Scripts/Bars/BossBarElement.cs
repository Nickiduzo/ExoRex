using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBarElement : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PointCounter pointCounter;
    public void ActivateBossBar()
    {
        slider.value = slider.maxValue;
        gameObject.SetActive(true);
    }
    public void OnDestroy()
    {
        gameObject.SetActive(false);
        pointCounter.UpdateKillCount(10);
    }
    public void SetMainValue(float value)
    {
        slider.value = slider.value - value;
    }

}
