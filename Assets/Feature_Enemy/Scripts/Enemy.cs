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
    [SerializeField] protected int enemyDamage;
    [SerializeField] protected LayerMask playerMask;
    [SerializeField] private float deadDelay = 1f;
    [SerializeField] protected int soulsDrop;   // 적 처치 시 드랍되는 소울의 양

    public bool isChasingPlayer = false;

    protected bool isFacingRight = true;    // 적이 바라보는 방향(적이 플레이어를 바라보는지 판단할 때 사용)

    protected SkeletonAnimation animator;
    protected Rigidbody2D rigid;
    [HideInInspector] public PlayerAction player;

    // Enemy 상태머신
    public EnemySM stateMachine;

    public abstract void Move();
    public abstract void Chase();
    public abstract void Patrol();
    public abstract bool DetectPlayer();

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
    public void ChangeAnimationSpeed(float speed)
    {
        animator.timeScale = speed;
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
        // 적이 사망 시 소울 드랍 구현 필요
        Debug.Log($"{enemyName}이(가) 죽었습니다. 드랍되는 소울: {soulsDrop}");
        Destroy(gameObject, deadDelay);
        ChangeAnimation("Dead");
    }
}
