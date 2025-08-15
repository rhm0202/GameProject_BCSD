using UnityEngine;
using Spine.Unity;

// 적 기본 클래스
// 애니메이션: Spine 사용
// 사용법은 몬스터 에셋 폴더 안에 Example Scene이랑 MonsterSqawner.cs 참고해주세요.
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string enemyName;
    [SerializeField] protected float hp;
    [SerializeField] protected float detectionRange;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int enemyDamage;
    public int EnemyDamage { get { return enemyDamage; } }

    [SerializeField] protected LayerMask playerMask;
    [SerializeField] private float deadDelay = 1f;
    [SerializeField] private GameObject soulPrefab; // 소울 프리팹
    [SerializeField] protected int soulsDrop;   // 적 처치 시 드랍되는 소울의 양

    public float applyedSpeed;

    public bool isChasingPlayer = false;

    protected bool isFacingRight = true;    // 적이 바라보는 방향(적이 플레이어를 바라보는지 판단할 때 사용)

    protected SkeletonAnimation animator;
    protected Rigidbody2D rigid;
    public PlayerAction player;

    public EnemySM stateMachine; // 상태 머신


    public abstract void Move();
    public abstract void Chase();
    public abstract void Patrol();
    public abstract bool DetectPlayer();

    protected virtual void Awake()
    {
        animator = GetComponent<SkeletonAnimation>();
        rigid = GetComponent<Rigidbody2D>();
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
        Destroy(gameObject, deadDelay);
        DropSoul();     // 처치시 소울 드랍
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerAction>();
            player.TakeDamage(EnemyDamage, transform.position);
        }
    }

    private void DropSoul()
    {
        for (int i = 0; i < soulsDrop; i++)
        {
            GameObject soul = Instantiate(soulPrefab, transform.position, Quaternion.identity);
        }
    }
}
