using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


// 스테이지 1의 보스
// 배회하며 일정 시간마다 통상 공격
// 플레이어의 위치로 점프 공격
public class Boss_Stage1 : Enemy
{
    private int direction = 1;
    public new Boss1SM stateMachine;

    [SerializeField] private float chasingSpeed = 5f;
    [SerializeField] private float patrolSpeed = 5f;

    [SerializeField] private GameObject attackHitbox;

    [HideInInspector] public bool isAttacking = false;

    public void StartBossFight()
    {
        player = FindAnyObjectByType<PlayerAction>().GetComponent<PlayerAction>();
        isFacingRight = false;
        applyedSpeed = patrolSpeed;
    }

    public override void Chase()
    {
        if (player == null)
        {
            return;
        }

        if (isFacingRight && player.transform.position.x < transform.position.x)
        {
            Flip();
        }
        else if (!isFacingRight && player.transform.position.x > transform.position.x)
        {
            Flip();
        }
    }

    public override bool DetectPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);
        if(target != null)
        {
            return true;
        }
        return false;
    }


    public override void Move()
    {
        direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = applyedSpeed * direction;
    }

    public override void Patrol()
    {
        applyedSpeed = patrolSpeed;
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new Boss1SM(this);
    }

    public void NormalAttack()
    {
        StartCoroutine(NAttackCoroutine());
    }

    private IEnumerator NAttackCoroutine()
    {
        yield return new WaitForSeconds(0.75f); // 공격 딜레이
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.6f); // 공격 후 딜레이
        attackHitbox.SetActive(false);
        stateMachine.TransitionTo(stateMachine.stateChasing);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            Move();
        }
    }
}
