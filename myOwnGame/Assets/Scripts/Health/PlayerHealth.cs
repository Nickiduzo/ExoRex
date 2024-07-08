using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private int minValue = 0;
    private int maxValue = 100;
    private int currentValue;

    private void Start()
    {
        currentValue = maxValue;
        UpdateHealthSlider();
    }

    public void DecreaseHealth(int decreaseValue)
    {
        if(currentValue - decreaseValue < minValue)
        {
            currentValue = minValue;
        }
        else
        {
            currentValue -= decreaseValue;
        }
        //Debug.Log(currentValue);
        UpdateHealthSlider();
    }

    private void IncreaseHealth(int increaseValue)
    {
        if(currentValue + increaseValue > maxValue)
        {
            currentValue = maxValue;
        }
        else
        {
            currentValue += increaseValue;
        }
        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentValue;
        }
    }
}
