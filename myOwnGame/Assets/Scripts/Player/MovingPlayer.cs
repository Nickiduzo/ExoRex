using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    public string movingAudio = "MoveLeg";
    
    [HideInInspector] public int hp;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private bool isRightSide = true;
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameOverScreen gameOver;
    
    private Animator anim;
    private AudioManager audioManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = AudioManager.instance;

        hp = SetHealth();
    }
    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.MovePosition(rigidBody.position + Vector2.right * move * maxSpeed * Time.deltaTime);

        if((move > 0f && !isRightSide) || (move < 0f && isRightSide))
        {
            if (move != 0f)
            {
                Spin();
            }
        }
    }

    private void Spin()
    {
        isRightSide = !isRightSide;
        transform.Rotate(0f, 180f, 0f);
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
