using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Death death;
    [SerializeField] private HealthPoints healthPoints;
    [SerializeField] private Slider slider;

    private void Start()
    {
        healthPoints.OnHealthChange += SetHealthBarValue;
        death.OnDieActivate += DestroyHealthBar;
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
    public void DestroyHealthBar() => Destroy(gameObject);
}
