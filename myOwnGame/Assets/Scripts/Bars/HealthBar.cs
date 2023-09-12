using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HealthPoints healthPoints;

    [SerializeField] private Death death;
    private void Start()
    {
        healthPoints.OnHealthChange += SetHealthBarValue;
        death.OnDieActivate += DestroyHealthBar;
    }
    private void OnDestroy()
    {
        healthPoints.OnHealthChange -= SetHealthBarValue;
        death.OnDieActivate -= DestroyHealthBar;
    }
    public void DestroyHealthBar()
    {
        Destroy(gameObject);
    }
    public void SetHealthBarValue(float currentValue)
    {
        float settedValue = currentValue;
        if(settedValue <= slider.minValue)
            settedValue = slider.minValue;

        if (settedValue >= slider.maxValue)
            settedValue = slider.maxValue;

        slider.value = settedValue;
    }
}
