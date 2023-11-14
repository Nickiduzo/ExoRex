using UnityEngine;

public class Boer : MonoBehaviour
{
    public Transform player;
    public float activationRadius = 0.3f;
    public float glowSpeed = 1.0f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= activationRadius)
            {
                // ����������, ���� ����� � �������
                Glow();
            }
            else
            {
                // ��������������� ����, ���� ����� ��� �������
                RestoreColor();
            }
        }
    }

    void Glow()
    {
        // ������������ ����� ������� ������ � ������ ���������
        Color targetColor = Color.yellow; // �� ������ ������������ ������ ����
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, Time.deltaTime * glowSpeed);
    }

    void RestoreColor()
    {
        // �������������� ������������� �����
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, originalColor, Time.deltaTime * glowSpeed);
    }
}
