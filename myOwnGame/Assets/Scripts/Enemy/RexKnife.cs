using UnityEngine;
using System.Collections;

public class RexKnifeArea : EnemyKnife
{
    [SerializeField] private float extendedAttackCooldown = 3f; // Увеличенный кулдаун атаки для RexKnifeArea
    [SerializeField] private float standStillTime = 2f; // Время, которое босс стоит на месте после атаки
    [SerializeField] private int increasedDamageToPlayer = 50; // Увеличенный урон для RexKnifeArea

    protected override void Start()
    {
        base.Start();
        // Дополнительная инициализация для RexKnifeArea, если необходимо
    }

    protected override void AttackPlayer()
    {
        anim.SetTrigger("isAttacking");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DecreaseHealth(increasedDamageToPlayer); // Увеличенный урон для RexKnifeArea
        }
        StartCoroutine(AttackCooldown());
    }

    protected override IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(extendedAttackCooldown); // Используем увеличенный кулдаун атаки
        canAttack = true;

        yield return new WaitForSeconds(standStillTime); // Пара секунд стоять на месте после атаки
    }

    // Если нужно, можно переопределить другие методы или добавить новые
}
