using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Flower : Enemy
{
    private int direction = 1;
    public bool isAttacking = false;

    public new FlowerSM stateMachine;

    [SerializeField] private float attackDelay = 5f;

    [SerializeField] private float inBattleSpeed;
    [SerializeField] private float patrolSpeed = 1f;

    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private Transform firePos;


    public override void Chase()
    {
        if (!isGazingPlayer())
        {
            Flip();
        }
    }
    public void Away()
    {
        if(isGazingPlayer())
        {
            Flip();
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
        applyedSpeed = inBattleSpeed;
    }

    public float DistanceToPlayer()
    {
        if (player == null)
        {
            return -1f;
        }
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        return distanceToPlayer;
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

    GameObject projectile;
    public void Attack()
    {
        if (projectile != null)
        {
            isAttacking = false;
            return;
        }
        if (!isGazingPlayer())
        {
            Flip();
        }
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        if (player != null)
        {
            yield return new WaitForSeconds(0.75f); // 공격 딜레이
            projectile = Instantiate(ProjectilePrefab, firePos.position, Quaternion.identity);
            Vector2 direction = player.transform.position - transform.position;
            projectile.GetComponent<Projectile>().Initialize(transform.position, direction);
        }
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }

    protected override void Dead()
    {
        base.Dead();
        stateMachine.TransitionTo(stateMachine.stateDead);
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new FlowerSM(this);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            return;
        }
        Move();
    }
}
