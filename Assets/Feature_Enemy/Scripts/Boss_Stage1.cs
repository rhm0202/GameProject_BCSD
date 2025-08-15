using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


// 스테이지 1의 보스
// 플레이어를 쫒아다니며 일정 시간마다 통상 공격
// 점프 공격
public class Boss_Stage1 : Enemy
{
    private int direction = 1;
    new Boss1SM stateMachine;

    [SerializeField] private float chasingSpeed = 5f;
    [SerializeField] protected float patrolSpeed = 1f;

    [SerializeField] private GameObject attackHitbox;

    [HideInInspector] public bool isAttacking = false;

    public override void Chase()
    {
        if (player == null)
        {
            return;
        }

        applyedSpeed = chasingSpeed;
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
            player = target.GetComponent<PlayerAction>();
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
        throw new System.NotImplementedException();
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new Boss1SM(this);
    }

    public void NormalAttack()
    {
        stateMachine.TransitionTo(stateMachine.stateNAttack);
        StartCoroutine(NAttackCoroutine());
    }

    private IEnumerator NAttackCoroutine()
    {
        yield return new WaitForSeconds(1f); // 공격 딜레이
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(1f); // 공격 후 딜레이
        attackHitbox.SetActive(false);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
