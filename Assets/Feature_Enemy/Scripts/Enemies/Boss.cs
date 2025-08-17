using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    [HideInInspector] public bool isAttacking = false;

    [SerializeField] protected float NAttackDelay = 0.75f; // 통상 공격 딜레이
    [SerializeField] protected float NAttackRecoveryDelay = 0.6f;

    [SerializeField] protected GameObject attackHitbox;

    public override void Chase()
    {
        if (player == null)
        {
            return;
        }

        if (!isGazingPlayer())
        {
            Flip();
        }
    }

    public override bool DetectPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);
        if (target != null)
        {
            return true;
        }
        return false;
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Patrol()
    {
    }

    public virtual void StartBossFight()
    {
        player = FindAnyObjectByType<PlayerAction>().GetComponent<PlayerAction>();
        if (!isGazingPlayer())
        {
            Flip();
        }
    }

    public void NormalAttack()
    {
        StartCoroutine(NAttackCoroutine());
    }
    private IEnumerator NAttackCoroutine()
    {
        yield return new WaitForSeconds(NAttackDelay); // 공격 딜레이
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(NAttackRecoveryDelay); // 공격 후 딜레이
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
}
