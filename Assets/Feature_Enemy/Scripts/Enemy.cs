using UnityEngine;
using Spine.Unity;

// 적 기본 클래스
// 애니메이션: Spine 사용
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string enemyName;
    [SerializeField] protected float hp;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float detectionRange;
    [SerializeField] protected float attackRange;
    [SerializeField] protected LayerMask playerLayer;

    [SerializeField] private float deadDelay = 1f;

    protected bool isFacingRight = true;    // 적이 바라보는 방향(적이 플레이어를 바라보는지 판단할 때 사용?)

    protected SkeletonAnimation animator;
    protected Rigidbody2D rigid;

    protected abstract void move();

    protected virtual void Awake()
    {
        animator = GetComponent<SkeletonAnimation>();
        rigid = GetComponent<Rigidbody2D>();

        ChangeAnimation("Idle");
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
        bool loop = animationName != "Dead";

        animator.AnimationState.SetAnimation(0, animationName, loop);
    }

    protected virtual void TakeDamage(float damage)
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
