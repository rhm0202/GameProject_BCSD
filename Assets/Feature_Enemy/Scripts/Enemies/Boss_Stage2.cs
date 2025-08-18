using System.Collections;
using UnityEngine;

public class Boss_Stage2 : Boss
{
    private Vector2 targetPos;
    [SerializeField] private float RAttackPosRange = 15f;
    [SerializeField] private float approachRange = 9f;
    [SerializeField] private float RAttackMoveSpeed = 5f;
    [SerializeField] private float approachSpeed = 9f;

    [SerializeField] private float burstDelay = 0.5f;
    [SerializeField] private int burstCount = 3;

    [SerializeField] private int projectileSpread = 25;     // 발사체의 퍼짐 정도 (각도)
    [SerializeField] private GameObject projectilePrefab;

    public float restTime = 2f;
    public bool isMoving = false;

    public new Boss2SM stateMachine;

    public override void Chase()
    {
        applyedSpeed = approachSpeed;
        approachRange = Random.Range(3f, 6f);
        SetTargetPos(approachRange);
        targetPos.y = player.transform.position.y + Random.Range(0f, 3f);
    }

    private void SetTargetPos(float range)
    {
        Vector2 randomLoc = Random.insideUnitCircle * range;
        randomLoc.y = Mathf.Abs(randomLoc.y);
        targetPos = (Vector2)player.transform.position + randomLoc;

        if (isFacingRight && targetPos.x < transform.position.x || !isFacingRight && targetPos.x > transform.position.x)
        {
            Flip();
        }
    }

    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, applyedSpeed * Time.fixedDeltaTime);
    }

    public bool isMovingTowardsTarget()
    {
        return Vector2.Distance(transform.position, targetPos) > 0.1f;
    }

    public void RangedAttack()
    {
        StartCoroutine(RAttackCoroutine());
    }

    private IEnumerator NAttackCoroutine()
    {
        if (!isGazingPlayer())
        {
            Flip();
        }
        yield return new WaitForSeconds(NAttackDelay);
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(NAttackRecoveryDelay);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
    private IEnumerator RAttackCoroutine()
    {
        applyedSpeed = RAttackMoveSpeed;
        SetTargetPos(RAttackPosRange);
        targetPos.y += Random.Range(2f, 5f);
        ChangeAnimation("Walk");

        while (isMovingTowardsTarget())
        {
            yield return new WaitForFixedUpdate();
        }

        if(!isGazingPlayer())
        {
            Flip();
        }
        ChangeAnimation("Attack");
        for (int i = 0; i < burstCount; i++)
        {
            ShootProjectiles();
            yield return new WaitForSeconds(burstDelay);
        }
        isAttacking = false;
    }

    private void ShootProjectiles()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        float baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        for (int angleOffset = -projectileSpread; angleOffset <= projectileSpread; angleOffset += projectileSpread)
        {
            float angle = baseAngle + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.GetComponent<Projectile>().Initialize(transform.position, direction);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new Boss2SM(this);
    }
    protected override void Dead()
    {
        base.Dead();
        stateMachine.TransitionTo(stateMachine.stateDead);
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
