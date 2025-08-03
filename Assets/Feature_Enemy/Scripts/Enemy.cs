using UnityEngine;
using Spine.Unity;

// 적 기본 클래스
// 애니메이션: Spine 사용
// 몬스터 에셋 폴더 안에 Example Scene이랑 MonsterSqawner.cs 참고해주세요.
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string enemyName;
    [SerializeField] protected float hp;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float detectionRange;
    [SerializeField] protected float attackRange;
    [SerializeField] protected LayerMask playerMask;
    [SerializeField] private float deadDelay = 1f;

    public bool isChasingPlayer = false;

    protected bool isFacingRight = true;    // 적이 바라보는 방향(적이 플레이어를 바라보는지 판단할 때 사용 ?)

    protected SkeletonAnimation animator;
    protected Rigidbody2D rigid;
    public PlayerAction player;

    // Enemy 상태머신
    public EnemySM stateMachine;

    public abstract void Move();
    public abstract void Chase();

    protected virtual void Awake()
    {
        animator = GetComponent<SkeletonAnimation>();
        rigid = GetComponent<Rigidbody2D>();
        stateMachine = new EnemySM(this);
    }

    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void ChangeAnimation(string animationName) //Names are: Idle, Walk, Dead and Attack
    {
        bool loop = (animationName != "Dead");

        animator.AnimationState.SetAnimation(0, animationName, loop);
    }

    public bool DetectPlayer()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, detectionRange, playerMask);

        if (target != null)
        {
            Vector2 dirToPlayer = target.transform.position - transform.position;
            if ((dirToPlayer.x > 0 && isFacingRight) || (dirToPlayer.x < 0 && !isFacingRight))
            {
                player = target.GetComponent<PlayerAction>();
                Debug.Log("플레이어가 적의 시야 범위 내에 있습니다.");
                return true;
            }
        }
        return false;
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    protected virtual void Dead()
    {
        Destroy(gameObject, deadDelay);
        ChangeAnimation("Dead");
    }
}
