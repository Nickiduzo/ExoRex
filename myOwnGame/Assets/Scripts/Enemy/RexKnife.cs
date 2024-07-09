using UnityEngine;
using System.Collections;

public class RexKnifeArea : EnemyKnife
{
    [SerializeField] private float extendedAttackCooldown = 3f; // ����������� ������� ����� ��� RexKnifeArea
    [SerializeField] private float standStillTime = 2f; // �����, ������� ���� ����� �� ����� ����� �����
    [SerializeField] private int increasedDamageToPlayer = 50; // ����������� ���� ��� RexKnifeArea

    protected override void Start()
    {
        base.Start();
        // �������������� ������������� ��� RexKnifeArea, ���� ����������
    }

    protected override void AttackPlayer()
    {
        anim.SetTrigger("isAttacking");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DecreaseHealth(increasedDamageToPlayer); // ����������� ���� ��� RexKnifeArea
        }
        StartCoroutine(AttackCooldown());
    }

    protected override IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(extendedAttackCooldown); // ���������� ����������� ������� �����
        canAttack = true;

        yield return new WaitForSeconds(standStillTime); // ���� ������ ������ �� ����� ����� �����
    }

    // ���� �����, ����� �������������� ������ ������ ��� �������� �����
}
