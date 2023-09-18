using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    public string movingAudio = "MoveLeg";
    
    [HideInInspector] public int hp;
    [SerializeField] private bool isRightSide = true;
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameOverScreen gameOver;


    private Animator anim;
    private AudioManager audioManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioManager = AudioManager.instance;

        hp = SetHealth();
    }

    public void TakeDamage(int damage)
    {
        if ((hp - damage) <= 0)
        {
            hp = 0;
            Die();
            return;
        }
        hp -= damage;
        anim.SetTrigger("takeDamage");
    }

    public void Die()
    {
        gameOver.Setup(PointCounter.ReturnFullScore());
    }
    public void MakeSoundStep()
    {
        audioManager.PlaySound(movingAudio);
    }

    public int SetHealth()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 0) return 150;
        return PlayerPrefs.GetInt("Difficulty");
    }
}
