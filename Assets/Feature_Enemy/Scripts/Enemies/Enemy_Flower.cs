using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Flower : Enemy
{
    private int direction = 1;
    public bool isAttacking = false;

    [SerializeField] private float attackDelay = 1f;

    [SerializeField] private float inBattleSpeed;
    [SerializeField] private float patrolSpeed = 1f;

    [SerializeField] private GameObject ProjectilePrefab;

    public override void Chase()
    {
        if (player == null)
        {
            return;
        }

    }

    public override bool DetectPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);

        if (target != null)
        {
            Vector2 dirToPlayer = target.transform.position - transform.position;
            if ((dirToPlayer.x > 0 && isFacingRight) || (dirToPlayer.x < 0 && !isFacingRight))
            {
                Debug.Log("플레이어가 적의 시야 범위 내에 있습니다.");
                return true;
            }
        }
        return false;
    }
    public void EnterBattle()
    {
        player = FindAnyObjectByType<PlayerAction>().GetComponent<PlayerAction>();
    }

    public override void Move()
    {
        direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = applyedSpeed * direction;
    }

    public override void Patrol()
    {
        applyedSpeed = patrolSpeed;
        if (!IsGroundAhead())
        {
            Flip();
        }
    }
    private bool IsGroundAhead()
    {
        Vector2 frontPoint = new Vector2(rigid.position.x + (isFacingRight ? 0.5f : -0.5f), rigid.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontPoint, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

        return hit.collider != null;
    }

    public void Attack()
    {
        if (player != null)
        {
            GameObject projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Vector2 direction = player.transform.position - transform.position;
            projectile.GetComponent<Projectile>().Initialize(transform.position, direction);
        }
    }


    private void FixedUpdate()
    {
        Move();
    }
}
