using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public delegate void HealthHandler(float percent);
    public event HealthHandler OnHealthChange;

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;
    //[SerializeField] private int minHealth = 0;

    public Death death;
    private Animator anim;
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
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
        TakeDamage(healthValue);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isTakeDamage");
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
        else
        {
            ChangeHealth(currentHealth);
        }
    }
    private void HandleDeath()
    {
        if (death != null)
        {
            death.Die();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
