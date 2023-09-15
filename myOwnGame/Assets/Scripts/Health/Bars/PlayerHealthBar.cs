using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float currentHealth;
    
    private float minHealth = 0;
    private float maxHealth = 150;

    private MovingPlayer player;

    private void Start()
    {
        player = GetComponent<MovingPlayer>();

        currentHealth = player.hp;
    }
    private void Update()
    {
        currentHealth = player.hp;

        if (DecreaseHp(currentHealth))
        {
            slider.value = currentHealth;
        }
    }
    public bool DecreaseHp(float currentHealth)
    {
        if (!currentHealth.Equals(maxHealth) || !currentHealth.Equals(minHealth))
            return true;

        return false;
    }
}
