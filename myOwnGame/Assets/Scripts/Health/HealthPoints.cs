using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public delegate void HealthHandler(float percent);
    public event HealthHandler OnHealthChange;

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int minHealth = 0;

    public Death death;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void ChangeHealth(int settedHealth)
    {
        currentHealth = settedHealth;
        OnHealthChange?.Invoke((float)currentHealth/maxHealth);
    }
    public void IncreaseHealth(int healthValue)
    {
        int settedHealth = currentHealth;

        if (settedHealth + healthValue > maxHealth)
        {
           settedHealth = maxHealth;
        }
        else
        {
           settedHealth += healthValue;
        }

        ChangeHealth(settedHealth);
    }
    public void DecreaseHealth(int healthValue)
    {
        int settedHealth = currentHealth;
        if (settedHealth - healthValue <= minHealth)
        {
            settedHealth = minHealth;
            death.Die();
        }
        else
        {
            settedHealth -= healthValue;
        }

        ChangeHealth(settedHealth);
    }
}
