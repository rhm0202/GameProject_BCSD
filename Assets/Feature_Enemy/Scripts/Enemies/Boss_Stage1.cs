using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


// 스테이지 1의 보스
// 배회하며 일정 시간마다 통상 공격
// 플레이어의 위치로 점프 공격
public class Boss_Stage1 : Boss
{
    private int direction = 1;
    public new Boss1SM stateMachine;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject shadowPrefab;       // 점프 공격 시 그림자
    [SerializeField] private ParticleSystem dust;           // 점프 착지 시 이펙트


    public override void StartBossFight()
    {
        base.StartBossFight();
        applyedSpeed = moveSpeed;
    }

    public override void Move()
    {
        direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = applyedSpeed * direction;
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new Boss1SM(this);
        Debug.Log("Boss_Stage1 Awake" + stateMachine);
    }

    public void JumpAttack()
    {
        StartCoroutine(JAttackCoroutine());
    }
    private IEnumerator NAttackCoroutine()
    {
        yield return new WaitForSeconds(NAttackDelay);
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(NAttackRecoveryDelay);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
    private IEnumerator JAttackCoroutine()
    {
        float shadowPosY = transform.position.y - 1;

        ChangeAnimation("Attack");
        ChangeAnimationSpeed(0.25f);
        yield return new WaitForSeconds(0.95f);
        rigid.linearVelocityY = 700f;
        ChangeAnimationSpeed(1f);

        while (true)
        {
            if (transform.position.y >= 500)
            {
                rigid.linearVelocityY = -10f;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        float playerPosX = player.transform.position.x;
        transform.position = new Vector2(playerPosX, transform.position.y);

        // 그림자 생성
        Vector2 shadowPos = new Vector2(playerPosX, shadowPosY);
        GameObject shadow = Instantiate(shadowPrefab, shadowPos, Quaternion.identity);
        

        while (true)
        {

            if (transform.position.y - player.transform.position.y < 210)
            {
                ChangeAnimation("Attack");
                Chase();
                break;
            }
            yield return new WaitForFixedUpdate();
        }

        while (true)
        {
            if (rigid.linearVelocityY >= 0)
            {
                Destroy(shadow);
                dust.Play();
                break;
            }
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

    protected override void Dead()
    {
        base.Dead();
        stateMachine.TransitionTo(stateMachine.stateDead);
    }

    private void Update()
    {
        Debug.Log("Boss_Stage1 Update" + stateMachine);
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        if (!isAttacking && !isResting)
        {
            Move();
        }
    }
}
