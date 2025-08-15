using UnityEngine;
using Spine.Unity;

// �� �⺻ Ŭ����
// �ִϸ��̼�: Spine ���
// ������ ���� ���� ���� �ȿ� Example Scene�̶� MonsterSqawner.cs �������ּ���.
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
    [SerializeField] private GameObject soulPrefab; // �ҿ� ������
    [SerializeField] protected int soulsDrop;   // �� óġ �� ����Ǵ� �ҿ��� ��

    public float applyedSpeed;

    public bool isChasingPlayer = false;

    protected bool isFacingRight = true;    // ���� �ٶ󺸴� ����(���� �÷��̾ �ٶ󺸴��� �Ǵ��� �� ���)

    protected SkeletonAnimation animator;
    protected Rigidbody2D rigid;
    public PlayerAction player;

    public EnemySM stateMachine; // ���� �ӽ�


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
        DropSoul();     // óġ�� �ҿ� ���
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
